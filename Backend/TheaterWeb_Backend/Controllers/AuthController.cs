using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheaterWeb.DataContext;
using TheaterWeb.Payloads.DataRequests.UserRequest;
using TheaterWeb.Services.Interfaces;

namespace TheaterWeb.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService) {
            _authService = authService;
        }
        // mailkit, mimekit
        [HttpPost("/api/auth/register")]
        public IActionResult Register([FromForm]Request_Register request) {
            return Ok(_authService.Register(request));
        }

        [HttpPost("/api/auth/login")]
        public IActionResult Login(Request_Login request) {
            return Ok(_authService.Login(request));
        }

        [HttpPost("/api/auth/confirm-create-new-account")]
        public IActionResult ConfirmCreateAccount(Request_ConfirmCreateAccount request) {
            return Ok(_authService.ConfirmCreateAccount(request));
        }

        [HttpPut("/api/auth/change-password")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult ChangePassword(Request_ChangePassword request) {
            var userClaim = HttpContext.User.FindFirst("Id");
            if (userClaim == null) {
                return BadRequest("Không tìm thấy user id trong token");
            }

            Guid id;
            string str = userClaim.Value;
            bool parseResult = Guid.TryParse(str, out id);
            if (!parseResult) {
                return BadRequest("User id không hợp lệ");
            }
            return Ok(_authService.ChangePasswword(id, request));
        }

        [HttpPut("/api/auth/forgot-password")]
        public IActionResult ForgotPassword(Request_ForgotPassword request) {
            return Ok(_authService.ForgotPassword(request));
        }

        [HttpPut("/api/auth/confirm-create-new-password")]
        public IActionResult ConfirmCreateNewPassword(Request_ConfirmCreateNewPassword request) {
            return Ok(_authService.ConfirmCreateNewPassword(request));
        }

        [HttpGet("/api/auth/get-all")]
        [Authorize(Roles = "Member")] //phân quyền để chỉ tài khoản có role như này mới có thể xem
        public IActionResult GetAll() {
            return Ok(_authService.GetAllUser());
        }
    }
}
