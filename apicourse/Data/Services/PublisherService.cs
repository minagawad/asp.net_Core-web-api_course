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
        }
    }
}
