using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using P_S_Reality.Models;

namespace P_S_Reality.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Agent> Agents { get; set; }

        public DbSet<BuyerSeller> BuyerSellers { get; set; }

        public DbSet<Neighborhood> Neighborhoods { get;set; }


    }
}
