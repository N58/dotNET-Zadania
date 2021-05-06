using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Zadanie_7.Forms;

namespace Zadanie_7.Pages
{
    public class HistorySessionModel : PageModel
    {
        public IList<FizzNumber> NumbersList { get; set; }

        public void OnGet()
        {
            var numbersList = HttpContext.Session.GetString("NumbersList");

            if (numbersList != null)
                NumbersList = JsonConvert.DeserializeObject<IList<FizzNumber>>(numbersList);
        }
    }
}
