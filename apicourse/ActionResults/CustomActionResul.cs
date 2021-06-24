using apicourse.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apicourse.ActionResults
{
    public class CustomActionResul : IActionResult
    {

        private readonly CustomActionResultVm _result;
        public CustomActionResul(CustomActionResultVm result)
        {
            _result = result;
        }
        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(_result.Exception ?? _result.Publisher as object)
            {
                StatusCode = _result.Exception != null ? StatusCodes.Status500InternalServerError :
                StatusCodes.Status200OK
            };
            await objectResult.ExecuteResultAsync(context);
        }
    }
}
