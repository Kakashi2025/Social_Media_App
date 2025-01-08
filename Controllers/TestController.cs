using Microsoft.AspNetCore.Mvc;

namespace WebApplicationSocialMediaApp.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("Backend is working!");
        }
    }

}
