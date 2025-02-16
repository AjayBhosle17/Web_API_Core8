using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [HttpGet]
        [Route("admindata")]
        [Authorize(Roles ="admin")]
        public IActionResult GetAdminData()
        {
            return Ok("You Are in Admin role");
        }

        [HttpGet]
        [Route("userdata")]
        [Authorize(Roles ="user")]
        public IActionResult GetUserData()
        {
            return Ok("You Are in User Role");
        }

        [HttpGet]
        [Route("publicdata")]
        public IActionResult NormalUser()
        {
            return Ok("You Are in Normal User Role");

        }
    }
}
