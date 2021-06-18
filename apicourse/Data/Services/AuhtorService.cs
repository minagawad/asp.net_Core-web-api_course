using apicourse.Data.Models;
using apicourse.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apicourse.Data.Services
{
    public class AuhtorService
    {
        private AppDbContext _context;
        public AuhtorService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorVm author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AutherWithBooksVm GetAutherWithBooks(int autherId)
        {
            var auther = _context.Authors.Where(a => a.Id == autherId).Select(a => new AutherWithBooksVm
            {
                FullName = a.FullName,
                BookTitles = a.Book_Authors.Select(a => a.Book.Title).ToList()


            }).FirstOrDefault();

            return auther;

        }
    }
}
