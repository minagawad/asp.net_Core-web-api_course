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
            _context.Books.Add(_book);
            _context.SaveChanges();
        }
        public List<Book> GetAllBooks() => _context.Books.ToList();
        public Book GetBookById(int bookid) => _context.Books.FirstOrDefault(n => n.Id == bookid);
        public Book UpdateBookById(int bookId , BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(b => b.Id == bookId);
            if(_book !=null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead.Value : null;
                _book.Rate = book.IsRead ? book.Rate.Value : null;
                _book.Genre = book.Genre;
                _book.CoverUrl = book.CoverUrl;
                _book.DateAdded = DateTime.Now;
                _context.SaveChanges();
            }
            return _book;
        }
    }
}
