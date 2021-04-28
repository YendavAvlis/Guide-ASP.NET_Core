using Microsoft.AspNetCore.Mvc;

namespace my_book.Controllers.v2
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Testing the Web API v2");
        }
    }
}