using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CarDealership.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace CarDealership.Data
{
    public class CarDealershipDbContext : IdentityDbContext<IdentityUser>
    {
        public CarDealershipDbContext(DbContextOptions<CarDealershipDbContext> options)
            : base(options)
        {
        }
        private IdentityUser GuestUser { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Dealership> Dealerships { get; set; }
        public DbSet<DealershipsCars> DealershipsCars { get; set; }
        public DbSet<GeneralManager> Employees { get; set; }

        // Remove seeding from here
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedUsers();
            modelBuilder.Entity<IdentityUser>()
                .HasData(GuestUser);

            modelBuilder.Entity<GeneralManager>()
                .HasOne(e => e.Dealerships)
                .WithMany(d => d.Employees)
                .HasForeignKey("DealershipId");

            modelBuilder.Entity<GeneralManager>()
                .HasOne(e => e.User)
                .WithOne(u => u.Employee)
                .HasForeignKey<GeneralManager>(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DealershipsCars>()
                .HasKey(dc => new { dc.DealershipId, dc.CarId });

            modelBuilder.Entity<DealershipsCars>()
                .HasOne(dc => dc.Dealership)
                .WithMany(d => d.DealershipsCars)
                .HasForeignKey(dc => dc.DealershipId);

            modelBuilder.Entity<DealershipsCars>()
                .HasOne(dc => dc.Car)
                .WithMany(c => c.DealershipsCars)
                .HasForeignKey(dc => dc.CarId);

            base.OnModelCreating(modelBuilder);
        }

        // Seed data method (after migrations)
        public void SeedUsers()
        {

            var hasher = new PasswordHasher<IdentityUser>();

            GuestUser = new IdentityUser()
            {
                Id = "180945ca-6809-4acb-9033-d34bbc9f973c", // You can generate this ID or make it unique
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com",
            };

            GuestUser.PasswordHash = hasher.HashPassword(GuestUser, "guest123");
        }
    }
}
