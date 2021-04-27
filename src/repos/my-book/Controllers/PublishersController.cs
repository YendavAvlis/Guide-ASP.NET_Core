using Microsoft.AspNetCore.Mvc;
using my_book.ActionResults;
using my_book.Data.Models.Services;
using my_book.Data.ViewModels;
using my_book.Exceptions;
using System;

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
            try
            {
                var newPublisher = _publisherService.AddPublisher(author);
                return Created(nameof(AddPublisher), newPublisher);
            }
            catch (PublisherNameException ex)
            {
                return BadRequest($"{ex.Message}, Publisher name: {ex.PublisherName}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-publisher-books-with-author/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var _response = _publisherService.GetPublisherData(id);
            return Ok(_response);
        }

        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var _response = _publisherService.GetPublisherById(id);
            if (_response != null)
            {
                return Ok(_response);

            }
            else
            {

                return NotFound("The publisher does not exist.");
            }
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            try
            {
                _publisherService.DeletePublisherById(id);
                return Ok("The publisher was successfully Deleted!!");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}