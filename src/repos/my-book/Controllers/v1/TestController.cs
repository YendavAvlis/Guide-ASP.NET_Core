using Microsoft.AspNetCore.Mvc;

namespace my_book.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Testing API on v1");
        }

    }
}