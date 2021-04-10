using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zadanie_4.Data;
using Zadanie_4.Forms;

namespace Zadanie_4.Numbers
{
    public class IndexModel : PageModel
    {
        private readonly Zadanie_4.Data.FizzContext _context;

        public IndexModel(Zadanie_4.Data.FizzContext context)
        {
            _context = context;
        }

        public IList<FizzNumber> FizzNumber { get;set; }

        public async Task OnGetAsync()
        {
            FizzNumber = await _context.FizzNumbers.OrderByDescending(p => p.DateTime).Take(10).ToListAsync();
        }
    }
}
