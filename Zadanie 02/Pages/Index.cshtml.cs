using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Zadanie2.Forms;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Zadanie2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public Address Address { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        public List<Address> AddressList { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(Name))
                Name = "User";
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // Read address list
                var listJSON = HttpContext.Session.GetString("SessionAddressList");
                if (listJSON != null)
                    AddressList = JsonConvert.DeserializeObject<List<Address>>(listJSON);
                else
                    AddressList = new List<Address>();

                // Add new address to list
                AddressList.Add(Address);
                HttpContext.Session.SetString("SessionAddressList", JsonConvert.SerializeObject(AddressList));

                HttpContext.Session.SetString("SessionAddress", JsonConvert.SerializeObject(Address));
                
                return RedirectToPage("./Address");
            }
            
            return Page();
        }
    }
}
