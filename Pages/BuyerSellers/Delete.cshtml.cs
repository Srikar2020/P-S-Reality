using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using P_S_Reality.Data;
using P_S_Reality.Models;

namespace P_S_Reality.Pages.BuyerSellers
{
    public class DeleteModel : PageModel
    {
        private readonly P_S_Reality.Data.ApplicationDbContext _context;

        public DeleteModel(P_S_Reality.Data.ApplicationDbContext context)
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

            var buyerseller = await _context.BuyerSellers.FirstOrDefaultAsync(m => m.BuyerSellerID == id);

            if (buyerseller == null)
            {
                return NotFound();
            }
            else
            {
                BuyerSeller = buyerseller;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buyerseller = await _context.BuyerSellers.FindAsync(id);
            if (buyerseller != null)
            {
                BuyerSeller = buyerseller;
                _context.BuyerSellers.Remove(BuyerSeller);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
