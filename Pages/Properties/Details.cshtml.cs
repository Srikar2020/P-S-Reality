using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using P_S_Reality.Data;
using P_S_Reality.Models;

namespace P_S_Reality.Pages.Properties
{
    public class DetailsModel : PageModel
    {
        private readonly P_S_Reality.Data.ApplicationDbContext _context;

        public DetailsModel(P_S_Reality.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Property Property { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property = await _context.Properties.FirstOrDefaultAsync(m => m.PropertyID == id);
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
    }
}
