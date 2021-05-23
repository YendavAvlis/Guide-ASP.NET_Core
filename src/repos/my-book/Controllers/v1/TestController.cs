using Microsoft.AspNetCore.Mvc;

namespace my_book.Controllers.v1
{
    //This is just a reminder in case you have forgotten
    //If you want to use the Swagger, please change the name
    //of the route name in "[HttpGet("get-test-data")]"
    //Because it gets crash and both cannot be running with the same name
    // :D
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("get-test-data")]
        public IActionResult Get()
        {
            return Ok("Testing API on v1");
        }

    }
}