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
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public FizzNumber FizzNumber { get; set; }
        public FizzNumber LastNumber { get; set; }
        public List<FizzNumber> NumbersList { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var lastNumber = HttpContext.Session.GetString("LastNumber");

            if (lastNumber != null)
                LastNumber = JsonConvert.DeserializeObject<FizzNumber>(lastNumber);
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                if (FizzNumber.Number % 3 == 0)
                    FizzNumber.Result += "Fizz";
                if (FizzNumber.Number % 5 == 0)
                    FizzNumber.Result += "Buzz";
                if (string.IsNullOrEmpty(FizzNumber.Result))
                    FizzNumber.Result = "Liczba " + FizzNumber.Number + " nie spełnia kryteriów Fizz/Buzz";

                FizzNumber.DateTime = DateTime.Now;

                HttpContext.Session.SetString("LastNumber", JsonConvert.SerializeObject(FizzNumber));

                var listJSON = HttpContext.Session.GetString("NumbersList");
                if (listJSON != null)
                    NumbersList = JsonConvert.DeserializeObject<List<FizzNumber>>(listJSON);
                else
                    NumbersList = new List<FizzNumber>();
                NumbersList.Add(FizzNumber);
                HttpContext.Session.SetString("NumbersList", JsonConvert.SerializeObject(NumbersList));

                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
