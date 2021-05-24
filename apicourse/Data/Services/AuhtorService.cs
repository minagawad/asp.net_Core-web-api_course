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
        }
    }
}
