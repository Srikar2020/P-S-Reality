using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using P_S_Reality.Data;
using P_S_Reality.Models;

namespace P_S_Reality.Pages.Properties
{
    public class PropertySearchModel : PageModel
    {
        private readonly P_S_Reality.Data.ApplicationDbContext _context;
        public PropertySearchModel(P_S_Reality.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<Property>? Property { get; set; }
        public bool SearchCompleted { get; set; }
        public string? Query { get; set; }

        public async Task OnGetAsync(string query)
        {
            Query = query;
            if (!string.IsNullOrWhiteSpace(query))
            {
                SearchCompleted = true;
                Property = await _context.Properties
                    .Where(x => x.Address.Contains(query))  //Can be any part of address, to allow for specific search or City
                    .ToListAsync();
            }
            else
            {
                SearchCompleted = false;
                Property = new List<Property>();
            }
        }
    }
}
