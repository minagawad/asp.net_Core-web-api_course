using apicourse.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace apicourse.Data.ViewModels
{
    public class CustomActionResultVm
    {
        public Exception Exception { get; set; }
        public Publisher  Publisher { get; set; }
    }
}
