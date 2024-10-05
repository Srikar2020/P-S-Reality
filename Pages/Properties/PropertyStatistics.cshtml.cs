using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using P_S_Reality.Data;
using P_S_Reality.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace P_S_Reality.Pages.Properties
{
    public class PropertyStatsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public PropertyStatsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public int TotalProperties { get; set; }
        public decimal PercentSold { get; set; }
        public decimal PercentLeased { get; set; }
        public decimal PercentAvailable { get; set; }
        public double AverageSqFt { get; set; }
        public decimal AveragePrice { get; set; }
        public double AverageRating { get; set; }

        public async Task OnGetAsync()
        {
            TotalProperties = await _context.Properties.CountAsync();
            PercentSold = (await _context.Properties.Where(x => x.Status.StartsWith("Sold")).CountAsync()) / (await _context.Properties.CountAsync()) * 100;
            PercentLeased = (await _context.Properties.Where(x => x.Status.StartsWith("Leased")).CountAsync()) / (await _context.Properties.CountAsync()) * 100;
            PercentAvailable = (await _context.Properties.Where(x => x.Status.StartsWith("Available")).CountAsync()) / (await _context.Properties.CountAsync()) * 100;
            AverageSqFt = await _context.Properties.AverageAsync(x => x.SquareFootage);
            AveragePrice = await _context.Properties.AverageAsync(x => x.Price);
            AverageRating = await _context.Properties.AverageAsync(x => x.Rating);
        }
    }
}
