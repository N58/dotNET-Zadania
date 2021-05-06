using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Zadanie_7.Data;
using Zadanie_7.Forms;
using System.Threading.Tasks;

namespace Zadanie_7.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public FizzNumber FizzNumber { get; set; }

        private readonly FizzContext _context;
        private IList<FizzNumber> NumbersList;

        public IndexModel(ILogger<IndexModel> logger, FizzContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                FizzNumber.UserId = userId;
                FizzNumber.Result = CheckFizzBuzz(FizzNumber.Number);
                FizzNumber.DateTime = DateTime.Now;
                
                // Add to database
                _context.FizzNumbers.Add(FizzNumber);
                _context.SaveChanges();

                // Add to session
                NumbersList = GetSession<FizzNumber>("NumbersList");
                NumbersList.Add(FizzNumber);
                HttpContext.Session.SetString("NumbersList", JsonConvert.SerializeObject(NumbersList));

                return RedirectToPage("./Index");
            }

            return Page();
        }

        private IList<T> GetSession<T>(string name)
        {
            var listJSON = HttpContext.Session.GetString(name);
            if (listJSON != null)
                return JsonConvert.DeserializeObject<IList<T>>(listJSON);
            else
                return new List<T>();
        }

        private int CheckFizzBuzz(int? number)
        {
            int result = 0;

            // For none: result == 0
            // For 3: result == 1
            // For 5: result == 2
            // For 3 and 5: result == 3
            if (number % 3 == 0)
                result += 1;
            if (number % 5 == 0)
                result += 2;

            return result;
        }
    }
}
