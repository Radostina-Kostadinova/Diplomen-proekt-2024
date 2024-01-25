using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TicketsHarbourApp.Infrastructure.Data.Domain;

namespace TicketsHarbourApp.Infastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
       public DbSet<Concert> Concerts { get; set; }
       public DbSet<Event> Events { get; set; }
      public DbSet<Location> Locations { get; set; }
       public DbSet<Order> Orders { get; set; }




    }
}
