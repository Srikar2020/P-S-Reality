using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using P_S_Reality.Data;
using P_S_Reality.Models;
using Microsoft.AspNetCore.Authorization;

namespace P_S_Reality.Pages.Properties
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly P_S_Reality.Data.ApplicationDbContext _context;

        public DeleteModel(P_S_Reality.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Property Property { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property = await _context.Properties.Include(x => x.Agent).Include(x => x.Neighborhood).FirstOrDefaultAsync(m => m.PropertyID == id);

            if (property == null)
            {
                return NotFound();
            }
            else
            {
                Property = property;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property = await _context.Properties.FindAsync(id);
            if (property != null)
            {
                Property = property;
                _context.Properties.Remove(Property);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
