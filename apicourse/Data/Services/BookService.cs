using apicourse.Data.Models;
using apicourse.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apicourse.Data.Services
{
    public class BookService
    {
        private AppDbContext _context;
        public BookService(AppDbContext context)
        {
            _context = context;

        }
        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {Title=book.Title,
            Description=book.Description,
            IsRead=book.IsRead,
            DateRead=book.IsRead?book.DateRead.Value:null,
            Rate=book.IsRead? book.Rate.Value:null,
            Genre=book.Genre,
            CoverUrl=book.CoverUrl,
            DateAdded=DateTime.Now

            };
            _context.books.Add(_book);
            _context.SaveChanges();
        }
        public List<Book> GetAllBooks() => _context.books.ToList();
        public Book GetBookById(int bookid) => _context.books.FirstOrDefault(n => n.Id == bookid);
    }
}
