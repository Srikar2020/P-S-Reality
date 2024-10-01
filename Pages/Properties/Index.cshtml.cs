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
    public class IndexModel : PageModel
    {
        private readonly P_S_Reality.Data.ApplicationDbContext _context;

        public IndexModel(P_S_Reality.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Property> Property { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Property = await _context.Properties
                .Include(p => p.Agent)
                .Include(p => p.Neighborhood)
                .ToListAsync();
        }
    }
}
