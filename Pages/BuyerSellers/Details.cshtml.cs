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
    public class DetailsModel : PageModel
    {
        private readonly P_S_Reality.Data.ApplicationDbContext _context;

        public DetailsModel(P_S_Reality.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
