using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Zadanie_08.Utils
{
    public class CustomFilterAttributes : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var result = context.Result;

            if (result is PageResult)
            {
                var page = ((PageResult)result);
                page.ViewData["ip"] = context.HttpContext.Connection.RemoteIpAddress.MapToIPv4();
            }

        }
    }
}
