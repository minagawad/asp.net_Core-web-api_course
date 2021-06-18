using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apicourse.Data.ViewModels
{
    public class AuthorVm
    {
        public string FullName { get; set; }
    }

    public class AutherWithBooksVm
    {
        public string FullName { get; set; }
        public List<string>  BookTitles { get; set; }

    }
}
