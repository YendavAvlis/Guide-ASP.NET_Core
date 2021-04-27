using Microsoft.AspNetCore.Mvc;
using my_book.Data.Models.Services;
using my_book.Data.ViewModels;

namespace my_book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        public PublisherService _publisherService;
        public PublishersController(PublisherService publisherService)
        {
            _publisherService = publisherService;
        }
        /*
        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            var allAuthors = _authorService.GetAllAuthors();
            return Ok(allAuthors);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            var allAuthors = _authorService.GetAuthorById(id);
            return Ok(allAuthors);
        }
            */
        [HttpPost]
        public IActionResult AddPublisher([FromBody] PublisherVM author)
        {
            _publisherService.AddPublisher(author);
            return Ok("The Publisher was added successfully!!");
        }

        [HttpGet("{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var _response = _publisherService.GetPublisherData(id);
            return Ok(_response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            _publisherService.DeletePublisherById(id);
            return Ok("The publisher was successfully Deleted!!");
        }
    }
}