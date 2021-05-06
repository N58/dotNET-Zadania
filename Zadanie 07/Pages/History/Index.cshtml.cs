using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zadanie_7.Data;
using Zadanie_7.Forms;

namespace Zadanie_7.Numbers
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly Zadanie_7.Data.FizzContext _context;

        public IndexModel(Zadanie_7.Data.FizzContext context)
        {
            _context = context;
        }

        public IList<FizzNumber> FizzNumber { get;set; }

        public async Task OnGetAsync()
        {
            FizzNumber = await _context.FizzNumbers.OrderByDescending(p => p.DateTime).Take(20).ToListAsync();
        }
    }
}
