using apicourse.ActionResults;
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
            //if (_response!=null)
            //{
            //    var _responseObject = new CustomActionRsultVm()
            //    {
            //        Publisher = _response

            //    };
            //    return CustomActionResul(_responseObject);

            //}
            return Ok(_response);
        }

        [HttpGet("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherByID (int id )
        {
            _publisherService.DeletePublisherById(id);
            return Ok();

        }


        [HttpGet("get-all-publishers")]
        public IActionResult GetAllPublishers( string orderby)
        {
          
            try
            {
                var _result = _publisherService.GetallPublisher(orderby);
                return Ok(_result);

            }
            catch (Exception)
            {

                return BadRequest("sorry We can't Load the publlishers");
            }

        }

    }
}
