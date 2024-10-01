using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using P_S_Reality.Data;
using P_S_Reality.Models;

namespace P_S_Reality.Pages.Neighborhoods
{
    public class IndexModel : PageModel
    {
        private readonly P_S_Reality.Data.ApplicationDbContext _context;

        public IndexModel(P_S_Reality.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Neighborhood> Neighborhood { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Neighborhood = await _context.Neighborhoods.ToListAsync();
        }
    }
}
