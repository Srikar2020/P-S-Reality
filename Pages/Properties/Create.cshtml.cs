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

namespace P_S_Reality.Pages.Properties
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
        ViewData["AgentID"] = new SelectList(_context.Agents, "AgentID", "Name");
        ViewData["NeighborhoodID"] = new SelectList(_context.Neighborhoods, "NeighborhoodID", "Name");
        ViewData["SellerID"] = new SelectList(_context.BuyerSellers, "BuyerSellerID", "FullName");
            return Page();
        }

        [BindProperty]
        public Property Property { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var sellerExists = await _context.BuyerSellers.AnyAsync(b => b.BuyerSellerID == Property.SellerID);
            if (!sellerExists)
            {
                ModelState.AddModelError("Property.SellerID", "The specified seller does not exist.");
                ViewData["AgentID"] = new SelectList(_context.Agents, "AgentID", "EmailAddress");
                ViewData["NeighborhoodID"] = new SelectList(_context.Neighborhoods, "NeighborhoodID", "City");
                ViewData["SellerID"] = new SelectList(_context.BuyerSellers, "BuyerSellerID", "FullName");
                return Page();
            }

            _context.Properties.Add(Property);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
