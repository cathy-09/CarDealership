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
    }
}
