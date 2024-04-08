using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheaterWeb.DataContext;
using TheaterWeb.Payloads.DataRequests;
using TheaterWeb.Services.Interfaces;

namespace TheaterWeb.Controllers {
    [ApiController]
    public class UserController : ControllerBase {
        private readonly IUserService _userService;
        public UserController(IUserService userService) {
            _userService = userService;
        }
        [HttpPost("api/auth/register")]
        public IActionResult Register([FromForm]RequestRegister request) {
            return Ok(_userService.Register(request));
        }
    }
}
