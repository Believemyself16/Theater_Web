using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Movie_Web.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using TheaterWeb.DataContext;
using TheaterWeb.Handle.Email;
using TheaterWeb.Handle.HandleEmailAndPhone;
using TheaterWeb.Payloads.Converters;
using TheaterWeb.Payloads.DataRequests.UserRequest;
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

        #region Đăng ký tài khoản và xác nhận đăng ký
        //đăng ký
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

            //nếu sai định dạng email, sđt
            if(!Validate.IsValidEmail(request.Email)) {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, "Định dạng email không hợp lệ!", null);
            }
            if (!Validate.IsValidPhoneNumber(request.PhoneNumber)) {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, "Định dạng số điện thoại không hợp lệ!", null);
            }

            //nếu email, tên tài khoản, sđt đã tồn tại
            if (_context.User.Any(x => x.Email.Equals(request.Email))) {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, "Email đã tồn tại trên hệ thống!", null);
            }
            if (_context.User.Any(x => x.Username.Equals(request.Username))) {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, "Tên tài khoản đã tồn tại trên hệ thống!", null);
            }
            if (_context.User.Any(x => x.PhoneNumber.Equals(request.PhoneNumber))) {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, "Số tài khoản đã tồn tại trên hệ thống!", null);
            }
            try {
                //add user vào csdl
                var user = new User();
                user.Username = request.Username;
                user.Email = request.Email;
                user.Name = request.Name;
                user.PhoneNumber = request.PhoneNumber;
                user.Password = BCryptNet.HashPassword(request.Password); //mã hóa mật khẩu truyền vào
                user.RoleId = 3;
                user.UserStatusId = 1;
                user.IsActive = false; //tài khoản chưa xác thực -> chưa active
                _context.User.Add(user);
                _context.SaveChanges();

                //add confirm email vào csdl
                ConfirmEmail confirmEmail = new ConfirmEmail {
                    UserId = user.Id,
                    IsConfirm = false,
                    ExpiredTime = DateTime.Now.AddHours(24),
                    RequiredTime = DateTime.Now,
                    ConfirmCode = "MyBugs" + "_" + GenerateCodeActive().ToString() //code để confirm tạo email
                };
                _context.Add(confirmEmail);
                _context.SaveChangesAsync();

                //1 email xác thực được gửi tới email người dùng
                string message = SendEmail(new EmailTo {
                    Mail = request.Email,
                    Subject = "Nhận mã xác nhận để đăng ký tài khoản mới ở đây: ",
                    Content = $"Mã xác thực của bạn là: {confirmEmail.ConfirmCode}, mã có hiệu lực trong 24 tiếng."
                });

                DataResponseUser result = _converter.EntityToDTO(user);
                return _responseObject.ResponseSuccess("Đăng ký tài khoản thành công", result);
            }
            catch (Exception ex) {
                return _responseObject.ResponseError(StatusCodes.Status500InternalServerError, ex.Message, null);
            }
        }

        //sau khi mail được gửi, xác nhận đăng ký tài khoản
        public ResponseObject<DataResponseUser> ConfirmCreateAccount(Request_ConfirmCreateAccount request) {
            //tìm email trong csdl có confirm code trùng với request code
            ConfirmEmail confirmEmail = _context.ConfirmEmail.Where(x => x.ConfirmCode.Equals(request.ConfirmCode)).FirstOrDefault();

            //nếu không có mail nào
            if (confirmEmail != null) {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, "Xác nhận đăng ký tài khoản thất bại!", null);
            }
            if (confirmEmail.ExpiredTime < DateTime.Now) {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, "Mã xác nhận đã hết hạn!", null);
            }
            User user = _context.User.FirstOrDefault(x => x.Id == confirmEmail.UserId);
            user.UserStatusId = 2; //sửa trạng thái người dùng
            _context.User.Add(user);
            _context.ConfirmEmail.Remove(confirmEmail); //xóa mail đã được kích hoạt khỏi csdl
            _context.SaveChanges();
            return _responseObject.ResponseSuccess("Xác nhận đăng ký tài khoản thành công!", _converter.EntityToDTO(user));
        }
        #endregion

        #region Gửi email xác thực tới người dùng
        public int GenerateCodeActive() {
            Random rnd = new Random();
            return rnd.Next(100000, 999999);
        }
        public string SendEmail(EmailTo emailTo) {
            if(!Validate.IsValidEmail(emailTo.Mail)) {
                return "Định dạng email không hợp lệ"; //thực ra mail đã phải đúng từ lúc đăng ký
            }
            //dùng smtp client để gửi mail xác thực
            var smtpClient = new SmtpClient("smtp.gmail.com") {
                Port = 587,
                Credentials = new NetworkCredential("minhquantb00@gmail.com", "jvztzxbtyugsiaea"), //đây là tk gửi mail xác thực tới các mail user
                EnableSsl = true, //kết nối được thiết lập qua SSL
            };

            try {
                var message = new MailMessage();
                message.From = new MailAddress("minhquantb00@gmail.com");
                message.To.Add(emailTo.Mail);
                message.Subject = emailTo.Subject;
                message.Body = emailTo.Content;
                message.IsBodyHtml = true; //hiển thị nội dung email dưới dạng HTML
                smtpClient.Send(message);
                return "Xác nhận gửi email thành công, lấy mã để xác thực";
            }
            catch (Exception ex) {
                return "Lỗi khi gửi mail: " + ex.Message;
            }
        }
        #endregion

        public DataResponseToken RenewAccessToken(User user) {
            throw new NotImplementedException();
        }

        #region Đăng nhập và tạo AccessToken, RefreshToken
        //đăng nhập
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

        //tạo refresh token random
        public string GenerateRefreshToken() {
            var random = new byte[32]; //tạo mảng byte
            //gán các giá trị ngẫu nhiên vào mảng
            using (var item = RandomNumberGenerator.Create()) {
                item.GetBytes(random);
                return Convert.ToBase64String(random);
            }
        }

        //tạo access token khi đăng nhập
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
        #endregion

        #region Lấy danh sách người dùng
        public IQueryable<DataResponseUser> GetAllUser() {
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
        #endregion
    }
}
