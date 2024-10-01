﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly P_S_Reality.Data.ApplicationDbContext _context;

        public DetailsModel(P_S_Reality.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Neighborhood Neighborhood { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neighborhood = await _context.Neighborhoods.FirstOrDefaultAsync(m => m.NeighborhoodID == id);
            if (neighborhood == null)
            {
                return NotFound();
            }
            else
            {
                Neighborhood = neighborhood;
            }
            return Page();
        }
    }
}
