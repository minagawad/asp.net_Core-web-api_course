using apicourse.Data.Services;
using apicourse.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apicourse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private PublisherService _publisherService;
        public PublisherController(PublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpPost("ad-publisher")]
        public IActionResult AddAuthor([FromBody] PublisherVm publisher)
        {
            _publisherService.AddPublisher(publisher);
            return Ok();

        }
        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var _response = _publisherService.GetPublisherData(id);
            return Ok(_response);
        }

        [HttpGet("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherByID (int id )
        {
            _publisherService.DeletePublisherById(id);
            return Ok();

        }

    }
}
