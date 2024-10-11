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

namespace P_S_Reality.Pages.Properties
{
    public class EditModel : PageModel
    {
        private readonly P_S_Reality.Data.ApplicationDbContext _context;

        public EditModel(P_S_Reality.Data.ApplicationDbContext context)
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

            var property =  await _context.Properties.FirstOrDefaultAsync(m => m.PropertyID == id);
            if (property == null)
            {
                return NotFound();
            }
            Property = property;
           ViewData["AgentID"] = new SelectList(_context.Agents, "AgentID", "Name");
           ViewData["NeighborhoodID"] = new SelectList(_context.Neighborhoods, "NeighborhoodID", "Name");
           ViewData["SellerID"] = new SelectList(_context.BuyerSellers, "BuyerSellerID", "FullName");
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

            _context.Attach(Property).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyExists(Property.PropertyID))
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

        private bool PropertyExists(int id)
        {
            return _context.Properties.Any(e => e.PropertyID == id);
        }
    }
}
