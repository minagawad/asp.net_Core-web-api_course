using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apicourse.Data.ViewModels
{
    public class PublisherVm
    {
        public string Name { get; set; }
    }
    public class PublisherWithBooksandWithersVm
    {
        public string  Name{ get; set; }
        public List<BookAutherVm> BookAuthers { get; set; }
    }
    public class BookAutherVm
    {
        public string BookName { get; set; }
        public List<string> BookAuthers { get; set; }


    }
}
