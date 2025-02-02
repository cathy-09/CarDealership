using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CarDealership.Data.Models;

namespace CarDealership.Data
{
    public class CarDealershipDbContext : DbContext
    {
        public CarDealershipDbContext(DbContextOptions<CarDealershipDbContext> options)
            : base(options)
        {
        }
        public DbSet<Cars> Cars { get; set; }
        public DbSet<Dealerships> Dealerships { get; set; }
        public DbSet<DealershipsCars> DealershipsCars { get; set; }
        public DbSet<Employees> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>()
                .HasOne(e => e.Dealerships)
                .WithMany(d => d.Employees)
                .HasForeignKey("DealershipId");

            modelBuilder.Entity<DealershipsCars>()
                .HasKey(dc => new { dc.DealershipId, dc.CarId });

            modelBuilder.Entity<DealershipsCars>()
                .HasOne(dc => dc.Dealerships)
                .WithMany(d => d.DealershipsCars)
                .HasForeignKey(dc => dc.DealershipId);

            modelBuilder.Entity<DealershipsCars>()
                .HasOne(dc => dc.Cars)
                .WithMany(c => c.DealershipsCars)
                .HasForeignKey(dc => dc.CarId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
