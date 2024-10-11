using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P_S_Reality.Data;
using P_S_Reality.Models;
using Microsoft.AspNetCore.Authorization;

namespace P_S_Reality.Pages.Neighborhoods
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly P_S_Reality.Data.ApplicationDbContext _context;

        public EditModel(P_S_Reality.Data.ApplicationDbContext context)
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

            var neighborhood =  await _context.Neighborhoods.FirstOrDefaultAsync(m => m.NeighborhoodID == id);
            if (neighborhood == null)
            {
                return NotFound();
            }
            Neighborhood = neighborhood;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Neighborhood).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NeighborhoodExists(Neighborhood.NeighborhoodID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool NeighborhoodExists(int id)
        {
            return _context.Neighborhoods.Any(e => e.NeighborhoodID == id);
        }
    }
}
