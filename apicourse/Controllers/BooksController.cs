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
    public class BooksController : ControllerBase
    {
        public BookService _bookservice;
        public BooksController(BookService bookService)
        {
            _bookservice = bookService;
        }
        [HttpPost("add-book-with-authers")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _bookservice.AddBookWithAuthors(book);
            return Ok();
        }
        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _bookservice.GetAllBooks();
            return Ok(allBooks);
        }
        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookservice.GetBookById(id);
            return Ok(book);
        }
        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] BookVM book)
        {
            var updatedbook = _bookservice.UpdateBookById(id,book);
            return Ok(book);
        }
    }
}
