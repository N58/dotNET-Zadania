using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Zadanie2.Forms;

namespace Zadanie2.Pages
{
    public class AddressModel : PageModel
    {
        public Address Address { get; set; }
        public List<Address> AddressList { get; set; }

        public void OnGet()
        {
            var SessionAddress = HttpContext.Session.GetString("SessionAddress");
            var SessionAddressList = HttpContext.Session.GetString("SessionAddressList");

            if (SessionAddress != null)
                Address = JsonConvert.DeserializeObject<Address>(SessionAddress);

            if (SessionAddressList != null)
                AddressList = JsonConvert.DeserializeObject<List<Address>>(SessionAddressList);
        }
    }
}
