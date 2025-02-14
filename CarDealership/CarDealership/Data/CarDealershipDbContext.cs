using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CarDealership.Data.Models;
using Microsoft.AspNetCore.Identity;
using Humanizer.Localisation;
using System.IO;
using static CarDealership.Data.DataConstants;
using static CarDealership.Common.AdminRole;

namespace CarDealership.Data
{
    public class CarDealershipDbContext : IdentityDbContext
    {
        public CarDealershipDbContext(DbContextOptions<CarDealershipDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Dealership> Dealerships { get; set; }
        public DbSet<DealershipsCars> DealershipsCars { get; set; }
        public DbSet<GeneralManager> GeneralManagers { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public IdentityUser AdminUser { get; set; }
        private IdentityUser GuestUser { get; set; }

        private List<Car> CarsList { get; set; }
        private List<Dealership> DealershipsList { get; set; }
        private List<GeneralManager> GeneralManagersList { get; set; }
        private List<DealershipsCars> DealershipsCarsList { get; set; }
        private List<Brand> BrandsList { get; set; }

        // Remove seeding from here
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DealershipsCars>().HasKey(dc => new
            { dc.CarId, dc.DealershipId });

            SeedUsers(modelBuilder);

            BrandsList = SeedBrands();
            modelBuilder.Entity<Brand>()
                .HasData(BrandsList);

            DealershipsList = SeedDealerships();
            modelBuilder.Entity<Dealership>()
                .HasData(DealershipsList);

            GeneralManagersList = SeedGeneralManagers();
            modelBuilder.Entity<GeneralManager>()
                .HasData(GeneralManagersList);

            CarsList = SeedCars();
            modelBuilder.Entity<Car>()
                .HasData(CarsList);

            DealershipsCarsList = SeedDealershipsCars();
            modelBuilder.Entity<DealershipsCars>()
                .HasData(DealershipsCarsList);

            base.OnModelCreating(modelBuilder);
        }

        private List<Brand> SeedBrands()
        {
            BrandsList = new List<Brand>
            {
                new Brand() 
                { 
                    BrandId = 1,
                    BrandName = "Skoda"
                },
                new Brand() 
                { 
                    BrandId = 2,
                    BrandName = "Alfa Romeo" 
                },
                new Brand() 
                { 
                    BrandId = 3,
                    BrandName = "BMW" 
                },
                new Brand() 
                {
                    BrandId = 4,
                    BrandName = "Fiat"
                },
                new Brand() 
                {
                    BrandId = 5, 
                    BrandName = "Ford" 
                },
                new Brand()
                { 
                    BrandId = 6,
                    BrandName = "Honda" 
                },
                new Brand()
                {
                    BrandId = 7,
                    BrandName = "Opel" 
                },
                new Brand() 
                { 
                    BrandId = 8, 
                    BrandName = "Audi" 
                },
                new Brand()
                {
                    BrandId = 9, 
                    BrandName = "Mercedes" 
                },
                new Brand() 
                {
                    BrandId = 10,
                    BrandName = "Nissan" 
                },
                new Brand()
                {
                    BrandId = 11, 
                    BrandName = "Volkswagen" 
                },
                new Brand() 
                {
                    BrandId = 12,
                    BrandName = "Toyota" 
                }
            };

            return BrandsList;
        }

        private List<GeneralManager> SeedGeneralManagers()
        {
            GeneralManagersList = new List<GeneralManager>
            {
                new GeneralManager()
                {
                    GeneralManagerId = 1,
                    FirstName = "James",
                    LastName = "Carter",
                    Email="james.carter@email.com",
                    PhoneNumber = "+44 7512 345678",
                    Salary = 5000.00m,
                    DealershipId = DealershipsList[0].DealershipId
                },
                new GeneralManager()
                {
                    GeneralManagerId = 2,
                    FirstName = "Emily",
                    LastName = "Johnson",
                    Email="emily.johnson@email.com",
                    PhoneNumber = "+1 415-555-1234",
                    Salary = 3000.00m,
                    DealershipId = DealershipsList[1].DealershipId
                },
                new GeneralManager()
                {
                    GeneralManagerId = 3,
                    FirstName = "Lucas",
                    LastName = "Bennett",
                    Email="jrlucas.bennett@email.com",
                    PhoneNumber = "+1 202-555-4321",
                    Salary = 10000.00m,
                    DealershipId = DealershipsList[2].DealershipId
                },
                new GeneralManager()
                {
                    GeneralManagerId = 4,
                    FirstName = "Charlotte",
                    LastName = "Robinson",
                    Email="charlotte.robinson@email.com",
                    PhoneNumber = "+44 7700 987654",
                    Salary = 900000m,
                    DealershipId = DealershipsList[3].DealershipId
                },
            };

            return GeneralManagersList;
        }

        private List<Dealership> SeedDealerships()
        {
            DealershipsList = new List<Dealership>
            {
                new Dealership() 
                { 
                    DealershipId = 1,
                    Name = "Elite Motors", 
                    Location = "London, United Kingdom" 
                },
                new Dealership() 
                {
                    DealershipId = 2,
                    Name = "Silverline Dealership", 
                    Location = "Sydney, Australia" 
                },
                new Dealership()
                { 
                    DealershipId = 3, 
                    Name = "Victory Wheels",
                    Location = "Madrid, Spain" },
                new Dealership() 
                { 
                    DealershipId = 4, 
                    Name = "Trusty Rides",
                    Location = "Dublin, Ireland"
                },
            };

            return DealershipsList;
        }

        private List<Car> SeedCars()
        {
            CarsList = new List<Car>
            {
                new Car()
                {            
                    CarId = 1,
                    BrandId = BrandsList[0].BrandId,
                    Model = "Octavia 2",
                    CarImageURL="https://www.google.com/url?sa=i&url=https%3A%2F%2Fbg.m.wikipedia.org%2Fwiki%2F%25D0%25A4%25D0%25B0%25D0%25B9%25D0%25BB%3ASkoda_Octavia_II_silver_vr.jpg&psig=AOvVaw28Xvk4Sykzwr3-x7PR9jA_&ust=1739651159020000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCPDIvNz_w4sDFQAAAAAdAAAAABAe",
                    Year = 2008,
                    FuelType = "diesel",
                    Kilometers = 399138,
                    HorsePower = 105,
                    Description = "Production years: from 2004 to 2013\r\n Engine displacement: from 1197 cm3 / 73 cu-in to 1984 cm3 / 121.1 cu-in\r\n Horsepower: from 75 PS / 74 HP / 55 kW to 200 PS / 197 HP / 147 kW\r\n Length: 457.2 cm / 180 inches Width: 176.9 cm / 69.65 inches Height: 146.2 cm / 57.56 inches Wheelbase: 257.8 cm / 101.5 inches\r\n CO2 emissions: from 119 to 242 g/Km",
                    Price = 6500.00m,
                    UserId = GuestUser.Id
                },
                new Car()
                {
                    CarId = 2,
                    BrandId = BrandsList[2].BrandId,
                    Model = "X5",
                    CarImageURL="https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.edmunds.com%2Fbmw%2Fx5%2F&psig=AOvVaw126ZB8ipJgwC5VWqTnrpkM&ust=1739651512091000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCOD6tIWBxIsDFQAAAAAdAAAAABAE",
                    Year = 2011,
                    FuelType = "gasoline",
                    Kilometers = 206000,
                    HorsePower = 306,
                    Description = "The BMW X5 has 1 Diesel Engine and 1 Petrol Engine on offer.\r\n The Diesel engine is 2993 cc while the Petrol engine is 2998 cc.\r\n It is available with Automatic transmission.\r\nDepending upon the variant and fuel type the X5 has a mileage of 12 kmpl. The X5 is a 5 seater 6 cylinder car and has length of 4922 mm,\r\n width of 2004 mm and a wheelbase of 2975 mm.",
                    Price = 22000.00m,
                    UserId = GuestUser.Id
                },
                new Car()
                {
                    CarId = 3,
                    BrandId = BrandsList[0].BrandId,
                    Model = "Octavia 3",
                    CarImageURL="https://www.google.com/url?sa=i&url=https%3A%2F%2Fautodata24.com%2Fskoda%2Foctavia%2Foctavia-iii-liftback%2Fdetails&psig=AOvVaw3EsEr0Gox55AxMKyhEFYnu&ust=1739651853052000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCMjun6eCxIsDFQAAAAAdAAAAABAE",
                    Year = 2016,
                    FuelType = "diesel",
                    Kilometers = 174000,
                    HorsePower = 110,
                    Description = " Production years: from 2013 to 2016\r\n Engine displacement: from 1197 cm3 / 73 cu-in to 1984 cm3 / 121.1 cu-in\r\n Horsepower: from 86 PS / 85 HP / 63 kW to 220 PS / 217 HP / 162 kW\r\n Length: 465.9 cm / 183.43 inches Width: 181.4 cm / 71.42 inches Height: 146.1 cm / 57.52 inches Wheelbase: 268.6 cm / 105.75 inches\r\n Curb Weight: from 1215 kg / 2679 lbs to 1470 kg / 3241 lbs\r\n CO2 emissions: from 97 to 142 g/Km",
                    Price = 35000.00m,
                    UserId = GuestUser.Id
                },
                new Car()
                {
                    CarId = 4,
                    BrandId = BrandsList[8].BrandId,
                    Model = "A6",
                    CarImageURL="https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.edmunds.com%2Fbmw%2Fx5%2F&psig=AOvVaw126ZB8ipJgwC5VWqTnrpkM&ust=1739651512091000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCOD6tIWBxIsDFQAAAAAdAAAAABAE",
                    Year = 2015,
                    FuelType = "gasoline",
                    Kilometers = 232000,
                    HorsePower = 272,
                    Description = "The Audi A6 has 1 Petrol Engine on offer. \r\nThe Petrol engine is 1984 cc . It is available with Automatic transmission.\r\nDepending upon the variant and fuel type the A6 has a mileage of 14.11 kmpl & Ground clearance of A6 is 165 mm. \r\nThe A6 is a 5 seater 4 cylinder car and has length of 4939 mm,\r\n width of 2110 mm and a wheelbase of 2500 mm.",
                    Price = 34500.00m,
                    UserId = GuestUser.Id
                },
            };

            return CarsList;
        }

        private List<DealershipsCars> SeedDealershipsCars()
        {
            DealershipsCarsList = new List<DealershipsCars>
            {
                new DealershipsCars()
                { 
                    CarId = 1, 
                    DealershipId = 1 
                },
                new DealershipsCars() 
                {
                    CarId = 1, 
                    DealershipId = 2 
                },
                new DealershipsCars()
                {
                    CarId = 2,
                    DealershipId = 3 
                },
                new DealershipsCars()
                {
                    CarId = 2, 
                    DealershipId = 4 
                },
                new DealershipsCars()
                {
                    CarId = 3,
                    DealershipId = 1 
                },
                new DealershipsCars()
                {
                    CarId = 3, 
                    DealershipId = 4 
                },
                new DealershipsCars() 
                { 
                    CarId = 4,
                    DealershipId = 3 
                },
                new DealershipsCars() 
                {
                    CarId = 4, 
                    DealershipId = 2
                },
            };

            return DealershipsCarsList;
        }

        private void SeedUsers(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<IdentityUser>();

            GuestUser = new IdentityUser()
            {
                UserName = "GuestUser@gmail.com",
                NormalizedUserName = "TEST@SOFTUNI.BG",
            };

            GuestUser.PasswordHash = hasher.HashPassword(GuestUser, "softuni");

            AdminUser = new IdentityUser()
            {
                Id = Guid.NewGuid().ToString(),
                Email = AdminEmail,
                NormalizedEmail = AdminEmail,
                UserName = AdminEmail,
                NormalizedUserName = AdminEmail,
            };

            AdminUser.PasswordHash = hasher.HashPassword(AdminUser, "admin");

            modelBuilder.Entity<IdentityUser>()
                .HasData(GuestUser, AdminUser);
        }
    }
}
