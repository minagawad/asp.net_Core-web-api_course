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
    public class AuthorController : ControllerBase
    {
        private AuhtorService _authorService;
        public AuthorController(AuhtorService auhtorService)
        {
            _authorService = auhtorService;
        }
        [HttpPost("ad-author")]
        public IActionResult AddAuthor([FromBody] AuthorVm author)
        {
            _authorService.AddAuthor(author);
            return Ok();

        }
    }
}
