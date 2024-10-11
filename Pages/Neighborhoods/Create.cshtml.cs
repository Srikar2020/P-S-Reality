using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using P_S_Reality.Data;
using P_S_Reality.Models;

namespace P_S_Reality.Pages.Neighborhoods
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly P_S_Reality.Data.ApplicationDbContext _context;

        public CreateModel(P_S_Reality.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Neighborhood Neighborhood { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Neighborhoods.Add(Neighborhood);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
