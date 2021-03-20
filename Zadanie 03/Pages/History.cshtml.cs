using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Zadanie_3.Forms;

namespace Zadanie_3.Pages
{
    public class HistoryModel : PageModel
    {
        public List<FizzNumber> NumbersList { get; set; }

        public void OnGet()
        {
            var numbersList = HttpContext.Session.GetString("NumbersList");

            if (numbersList != null)
                NumbersList = JsonConvert.DeserializeObject<List<FizzNumber>>(numbersList);
        }
    }
}
