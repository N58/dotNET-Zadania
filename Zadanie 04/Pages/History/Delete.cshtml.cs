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
    public class DeleteModel : PageModel
    {
        private readonly Zadanie_4.Data.FizzContext _context;

        public DeleteModel(Zadanie_4.Data.FizzContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FizzNumber FizzNumber { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FizzNumber = await _context.FizzNumbers.FirstOrDefaultAsync(m => m.Id == id);

            if (FizzNumber == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FizzNumber = await _context.FizzNumbers.FindAsync(id);

            if (FizzNumber != null)
            {
                _context.FizzNumbers.Remove(FizzNumber);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
