using apicourse.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace apicourse.Data.Services
{
    public class PublisherService
    {
        private AppDbContext _context;
        public PublisherService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public void AddPublisher(PublisherVm publisher)
        {
            var _publisher = new Data.Models.Publisher()
            {
                Name = publisher.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }

        public PublisherWithBooksandWithersVm GetPublisherData(int publisherId)
        {
            var _publisher = _context.Publishers.Where(p => p.Id == publisherId).Select
                (p => new PublisherWithBooksandWithersVm
                {
                    Name = p.Name,
                    BookAuthers = p.Books.Select(b => new BookAutherVm()
                    {
                        BookName = b.Title,
                        BookAuthers = b.Book_Authors.Select(n => n.Author.FullName).ToList()

                    }).ToList(),



                }).FirstOrDefault();
            return _publisher;

        }


        public void DeletePublisherById(int id)
        {
            var _publisher = _context.Publishers.FirstOrDefault(p => p.Id == id);
            if (_publisher != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }

        }
        public List<Data.Models.Publisher> GetallPublisher( string orderBy)
        {


            var allPublishers = _context.Publishers.OrderBy(p => p.Name).ToList();
            if (!string.IsNullOrEmpty(orderBy))
            {
                switch (orderBy)
                {
                    case "name_desc":
                        allPublishers = allPublishers.OrderByDescending(p => p.Name).ToList();
                        break;
                    default:
                        break;
                }
            }
           
            return allPublishers;
        }
    }
}
