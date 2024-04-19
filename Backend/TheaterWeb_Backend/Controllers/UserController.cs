using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheaterWeb.DataContext;
using TheaterWeb.Payloads.DataRequests.UserRequest;
using TheaterWeb.Services.Interfaces;

namespace TheaterWeb.Controllers
{
    [ApiController]
    public class UserController : ControllerBase {
        private readonly IUserService _userService;
        public UserController(IUserService userService) {
            _userService = userService;
        }
        // mailkit, mimekit
        [HttpPost("api/auth/register")]
        public IActionResult Register([FromForm]Request_Register request) {
            return Ok(_userService.Register(request));
        }

        [HttpPost("api/auth/login")]
        public IActionResult Login(Request_Login request) {
            return Ok(_userService.Login(request));
        }

        [HttpGet("api/auth/get-all")]
        [Authorize(Roles = "Member")] //phân quyền để chỉ tài khoản có role như này mới có thể xem
        public IActionResult GetAll() {
            return Ok(_userService.GetAllUser());
        }
    }
}
