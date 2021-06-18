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
        //public void AddBook(BookVM book)
        ////{
        //    var _book = new Book()
        //    {Title=book.Title,
        //    Description=book.Description,
        //    IsRead=book.IsRead,
        //    DateRead=book.IsRead?book.DateRead.Value:null,
        //    Rate=book.IsRead? book.Rate.Value:null,
        //    Genre=book.Genre,
        //    CoverUrl=book.CoverUrl,
        //    DateAdded=DateTime.Now,
        //    PublisherId=book.PublisherId,

            

        //    };
        //    _context.Books.Add(_book);
        //    _context.SaveChanges();
        //}
        public List<Book> GetAllBooks() => _context.Books.ToList();
       
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
            //foreach (var item in book.AutherIds)
            //{
            //    var book_auther = new Book_Author()
            //    {
            //        BookId = _book.Id,
            //        AuthorId = item,
            //    };
            //    _context.Books_Authors.Add(book_auther);
            //    _context.SaveChanges();

            //}
            return _book;
        }

        public BookWithAuthorsVM GetBookById(int bookId)
        {
            var _bookWithAuthors = _context.Books.Where(n => n.Id == bookId).Select(book => new BookWithAuthorsVM()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                PublisherName = book.Publisher.Name,
                AutherNames = book.Book_Authors.Select(n => n.Author.FullName).ToList()
            }).FirstOrDefault();

            return _bookWithAuthors;
        }




        public void AddBookWithAuthors(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherId
            };
            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach (var id in book.AutherIds)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = id
                };
                _context.Books_Authors.Add(_book_author);
                _context.SaveChanges();
            }
        }
    }
}
