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

namespace P_S_Reality.Pages.Neighborhoods
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
        public Neighborhood Neighborhood { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neighborhood = await _context.Neighborhoods.FirstOrDefaultAsync(m => m.NeighborhoodID == id);

            if (neighborhood == null)
            {
                return NotFound();
            }
            else
            {
                Neighborhood = neighborhood;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neighborhood = await _context.Neighborhoods.FindAsync(id);
            if (neighborhood != null)
            {
                Neighborhood = neighborhood;
                _context.Neighborhoods.Remove(Neighborhood);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
