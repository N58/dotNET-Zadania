using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Shyjus.BrowserDetection;

namespace Zadanie_6
{
    public class BrowserNameMiddleware
    {
        private RequestDelegate _next;

        public BrowserNameMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context, IBrowserDetector browserDetector)
        {
            var _browserDetector = browserDetector;
            var name = _browserDetector.Browser.Name;

            if (name == BrowserNames.Edge
                || name == BrowserNames.EdgeChromium
                || name == BrowserNames.InternetExplorer)
                context.Response.WriteAsync("Przegladarka nie jest obslugiwana");

            return _next(context);
        }
    }

    public static class BrowserNameMiddlewareExtensions
    {
        public static IApplicationBuilder BrowserNameMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BrowserNameMiddleware>();
        }
    }
}
