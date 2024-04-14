using Microsoft.IdentityModel.Tokens;
using Movie_Web.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using TheaterWeb.DataContext;
using TheaterWeb.Handle.Email;
using TheaterWeb.Payloads.Converters;
using TheaterWeb.Payloads.DataRequests;
using TheaterWeb.Payloads.DataResponses;
using TheaterWeb.Payloads.Responses;
using TheaterWeb.Services.Interfaces;
using BCryptNet = BCrypt.Net.BCrypt;

namespace TheaterWeb.Services.Implements
{
    public class UserService : BaseService, IUserService {
        private readonly ResponseObject<DataResponseUser> _responseObject;
        private readonly UserConverter _converter;
        private readonly IConfiguration _configuration;
        private readonly ResponseObject<DataResponseToken> _responseTokenObject;
        private readonly HttpContextAccessor _httpContextAccessor;

        public UserService(IConfiguration configuration) {
            _converter = new UserConverter();
            _responseObject = new ResponseObject<DataResponseUser>();
            _configuration = configuration;
            _responseTokenObject = new ResponseObject<DataResponseToken>();
            _httpContextAccessor = new HttpContextAccessor();
        }

        //đăng ký tài khoản
        public ResponseObject<DataResponseUser> Register(Request_Register request) {
            //nếu data nhập vào rỗng
            if(string.IsNullOrWhiteSpace(request.Username)
                || string.IsNullOrWhiteSpace(request.Email)
                || string.IsNullOrWhiteSpace(request.Name)
                || string.IsNullOrWhiteSpace(request.PhoneNumber)
                || string.IsNullOrWhiteSpace(request.Password))
            {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, "Vui lòng điền đầy đủ thông tin!", null); 
            }
            //nếu email đã đăng ký
            if(_context.User.Any(x => x.Email.Equals(request.Email))) {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, "Email đã tồn tại trên hệ thống!", null);
            }
            if (_context.User.Any(x => x.Username.Equals(request.Username))) {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, "Tên tài khoản đã tồn tại trên hệ thống!", null);
            }
            //nếu sai định dạng email
            if(!Validate.IsValidEmail(request.Email)) {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, "Định dạng email không hợp lệ!", null);
            }
            var user = new User();
            user.Username = request.Username;
            user.Email = request.Email;
            user.Name = request.Name;
            user.PhoneNumber = request.PhoneNumber;
            user.Password = BCryptNet.HashPassword(request.Password); //mã hóa mật khẩu truyền vào
            user.RoleId = 3;
            user.RankCustomerId = 1;
            user.UserStatusId = 1;
            _context.User.Add(user);
            _context.SaveChanges();
            DataResponseUser result = _converter.EntityToDTO(user);
            return _responseObject.ResponseSuccess("Đăng ký tài khoản thành công", result);
        }

        //tạo refresh token random
        public string GenerateRefreshToken() {
            var random = new byte[32]; //tạo mảng byte
            //gán các giá trị ngẫu nhiên vào mảng
            using (var item = RandomNumberGenerator.Create()) {
                item.GetBytes(random);
                return Convert.ToBase64String(random);
            }
        }

        public DataResponseToken GenerateAccessToken(User user) {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:SecretKey").Value);
            
            var role = _context.Role.FirstOrDefault(x => x.Id == user.RoleId); //lấy ra quyền của role này

            //mô tả token
            var tokenDiscription = new SecurityTokenDescriptor {
                Subject = new System.Security.Claims.ClaimsIdentity(new[] {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Email", user.Email),
                    new Claim(ClaimTypes.Role, role?.Code ?? "") //nếu không null thì lấy ra được rolename, không thì là ""
                }),
                Expires = DateTime.Now.AddHours(4), //mỗi 4 giờ thì token hết hạn
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            //tạo token
            var token = jwtTokenHandler.CreateToken(tokenDiscription);
            var accessToken = jwtTokenHandler.WriteToken(token); //chuyển token sang dạng chuỗi
            var refreshToken = GenerateRefreshToken();

            //tạo thực thể trong csdl
            RefreshToken rf = new RefreshToken {
                Token = refreshToken,
                ExpiredTime = DateTime.Now.AddDays(1), //thời gian expire phải lớn hơn thời gian token được tạo
                UserId = user.Id
            };
            _context.RefreshToken.Add(rf);
            _context.SaveChanges();

            //dữ liệu trả về
            DataResponseToken result = new DataResponseToken {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            };
            return result;
        }

        public DataResponseToken RenewAccessToken(User user) {
            throw new NotImplementedException();
        }

        public ResponseObject<DataResponseToken> Login(Request_Login request) {
            var user = _context.User.FirstOrDefault(x => x.Username.Equals(request.UserName));

            //nếu tài khoản hoặc mật khẩu chưa nhập
            if(string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password)) {
                return _responseTokenObject.ResponseError(StatusCodes.Status400BadRequest, "Vui lòng điền đầy đủ thông tin", null);
            }

            //kiểm tra mật khẩu
            bool checkPass = BCryptNet.Verify(request.Password, user.Password);
            if(!checkPass) {
                return _responseTokenObject.ResponseError(StatusCodes.Status400BadRequest, "Mật khẩu không chính xác", null);
            }
            return _responseTokenObject.ResponseSuccess("Đăng nhập thành công", GenerateAccessToken(user)); //nhập đúng mật khẩu thì tạo access token
        }

        //lấy thông tin người dùng
        public IQueryable<DataResponseUser> GetAll() {
            //var currentUser = _httpContextAccessor.HttpContext.User;
            //if(!currentUser.Identity.IsAuthenticated) {
            //    throw new UnauthorizedAccessException("Người dùng không được xác thực hoặc không được xác định");
            //}
            //if(!currentUser.IsInRole("Admin")) {
            //    throw new UnauthorizedAccessException("Người dùng không có quyền sử dụng chức năng này");
            //}
            var result = _context.User.Select(x => _converter.EntityToDTO(x));
            return result;
        }
    }
}
