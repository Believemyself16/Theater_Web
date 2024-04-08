using Movie_Web.Entities;
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
    public class UserService : IUserService {
        private readonly AppDbContext _context;
        private readonly ResponseObject<DataResponseUser> _responseObject;
        private readonly UserConverter _converter;
        public UserService() {
            _context = new AppDbContext();
            _converter = new UserConverter();
            _responseObject = new ResponseObject<DataResponseUser>();
        }
        //đăng ký tài khoản
        public ResponseObject<DataResponseUser> Register(RequestRegister request) {
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
            _context.User.Add(user);
            _context.SaveChanges();
            DataResponseUser result = _converter.EntityToDTO(user);
            return _responseObject.ResponseSuccess("Đăng ký tài khoản thành công", result);
        }
    }
}
