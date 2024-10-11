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
        public decimal NumberSold { get; set; }
        public decimal NumberLeased { get; set; }
        public decimal NumberAvailable { get; set; }
        public double AverageSqFt { get; set; }
        public string SqFtCommas { get; set; }
        public decimal AveragePrice { get; set; }
        public string PriceCommas { get; set; }
        public double AverageRating { get; set; }

        public async Task OnGetAsync()
        {
            TotalProperties = await _context.Properties.CountAsync();
            // Number in Each Status
            NumberSold = (await _context.Properties.Where(x => x.Status.Contains("Sold")).CountAsync());
            NumberLeased = (await _context.Properties.Where(x => x.Status.Contains("Leased")).CountAsync());
            NumberAvailable = (await _context.Properties.Where(x => x.Status.Contains("Available")).CountAsync());
            AverageSqFt = await _context.Properties.AverageAsync(x => x.SquareFootage);
            AverageSqFt = Math.Round(AverageSqFt, 0);
            // Converting to String to Use Comma Separators for Large Numbers
            SqFtCommas = AverageSqFt.ToString("N0");
            AveragePrice = await _context.Properties.AverageAsync(x => x.Price);
            AveragePrice = Math.Round(AveragePrice, 0);
            PriceCommas = AveragePrice.ToString("N0");
            AverageRating = await _context.Properties.AverageAsync(x => x.Rating);
            AverageRating = Math.Round(AverageRating, 2);
        }
    }
}
