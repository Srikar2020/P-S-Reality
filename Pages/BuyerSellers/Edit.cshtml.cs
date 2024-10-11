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

namespace P_S_Reality.Pages.BuyerSellers
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
        public BuyerSeller BuyerSeller { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buyerseller =  await _context.BuyerSellers.FirstOrDefaultAsync(m => m.BuyerSellerID == id);
            if (buyerseller == null)
            {
                return NotFound();
            }
            BuyerSeller = buyerseller;
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

            _context.Attach(BuyerSeller).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuyerSellerExists(BuyerSeller.BuyerSellerID))
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

        private bool BuyerSellerExists(int id)
        {
            return _context.BuyerSellers.Any(e => e.BuyerSellerID == id);
        }
    }
}
