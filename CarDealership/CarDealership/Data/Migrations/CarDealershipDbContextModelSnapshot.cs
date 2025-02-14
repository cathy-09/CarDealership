﻿// <auto-generated />
using System;
using CarDealership.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarDealership.Data.Migrations
{
    [DbContext(typeof(CarDealershipDbContext))]
    partial class CarDealershipDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarDealership.Data.Models.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrandId"), 1L, 1);

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("BrandId");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            BrandId = 1,
                            BrandName = "Skoda"
                        },
                        new
                        {
                            BrandId = 2,
                            BrandName = "Alfa Romeo"
                        },
                        new
                        {
                            BrandId = 3,
                            BrandName = "BMW"
                        },
                        new
                        {
                            BrandId = 4,
                            BrandName = "Fiat"
                        },
                        new
                        {
                            BrandId = 5,
                            BrandName = "Ford"
                        },
                        new
                        {
                            BrandId = 6,
                            BrandName = "Honda"
                        },
                        new
                        {
                            BrandId = 7,
                            BrandName = "Opel"
                        },
                        new
                        {
                            BrandId = 8,
                            BrandName = "Audi"
                        },
                        new
                        {
                            BrandId = 9,
                            BrandName = "Mercedes"
                        },
                        new
                        {
                            BrandId = 10,
                            BrandName = "Nissan"
                        },
                        new
                        {
                            BrandId = 11,
                            BrandName = "Volkswagen"
                        },
                        new
                        {
                            BrandId = 12,
                            BrandName = "Toyota"
                        });
                });

            modelBuilder.Entity("CarDealership.Data.Models.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarId"), 1L, 1);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("CarImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("FuelType")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("HorsePower")
                        .HasColumnType("int");

                    b.Property<int>("Kilometers")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("CarId");

                    b.HasIndex("BrandId");

                    b.HasIndex("UserId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            CarId = 1,
                            BrandId = 1,
                            CarImageURL = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fbg.m.wikipedia.org%2Fwiki%2F%25D0%25A4%25D0%25B0%25D0%25B9%25D0%25BB%3ASkoda_Octavia_II_silver_vr.jpg&psig=AOvVaw28Xvk4Sykzwr3-x7PR9jA_&ust=1739651159020000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCPDIvNz_w4sDFQAAAAAdAAAAABAe",
                            Description = "Production years: from 2004 to 2013\r\n Engine displacement: from 1197 cm3 / 73 cu-in to 1984 cm3 / 121.1 cu-in\r\n Horsepower: from 75 PS / 74 HP / 55 kW to 200 PS / 197 HP / 147 kW\r\n Length: 457.2 cm / 180 inches Width: 176.9 cm / 69.65 inches Height: 146.2 cm / 57.56 inches Wheelbase: 257.8 cm / 101.5 inches\r\n CO2 emissions: from 119 to 242 g/Km",
                            FuelType = "diesel",
                            HorsePower = 105,
                            Kilometers = 399138,
                            Model = "Octavia 2",
                            Price = 6500.00m,
                            UserId = "7cf7bb02-bad8-4cca-9a97-68ffec8ae0c0",
                            Year = 2008
                        },
                        new
                        {
                            CarId = 2,
                            BrandId = 3,
                            CarImageURL = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.edmunds.com%2Fbmw%2Fx5%2F&psig=AOvVaw126ZB8ipJgwC5VWqTnrpkM&ust=1739651512091000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCOD6tIWBxIsDFQAAAAAdAAAAABAE",
                            Description = "The BMW X5 has 1 Diesel Engine and 1 Petrol Engine on offer.\r\n The Diesel engine is 2993 cc while the Petrol engine is 2998 cc.\r\n It is available with Automatic transmission.\r\nDepending upon the variant and fuel type the X5 has a mileage of 12 kmpl. The X5 is a 5 seater 6 cylinder car and has length of 4922 mm,\r\n width of 2004 mm and a wheelbase of 2975 mm.",
                            FuelType = "gasoline",
                            HorsePower = 306,
                            Kilometers = 206000,
                            Model = "X5",
                            Price = 22000.00m,
                            UserId = "7cf7bb02-bad8-4cca-9a97-68ffec8ae0c0",
                            Year = 2011
                        },
                        new
                        {
                            CarId = 3,
                            BrandId = 1,
                            CarImageURL = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fautodata24.com%2Fskoda%2Foctavia%2Foctavia-iii-liftback%2Fdetails&psig=AOvVaw3EsEr0Gox55AxMKyhEFYnu&ust=1739651853052000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCMjun6eCxIsDFQAAAAAdAAAAABAE",
                            Description = " Production years: from 2013 to 2016\r\n Engine displacement: from 1197 cm3 / 73 cu-in to 1984 cm3 / 121.1 cu-in\r\n Horsepower: from 86 PS / 85 HP / 63 kW to 220 PS / 217 HP / 162 kW\r\n Length: 465.9 cm / 183.43 inches Width: 181.4 cm / 71.42 inches Height: 146.1 cm / 57.52 inches Wheelbase: 268.6 cm / 105.75 inches\r\n Curb Weight: from 1215 kg / 2679 lbs to 1470 kg / 3241 lbs\r\n CO2 emissions: from 97 to 142 g/Km",
                            FuelType = "diesel",
                            HorsePower = 110,
                            Kilometers = 174000,
                            Model = "Octavia 3",
                            Price = 35000.00m,
                            UserId = "7cf7bb02-bad8-4cca-9a97-68ffec8ae0c0",
                            Year = 2016
                        },
                        new
                        {
                            CarId = 4,
                            BrandId = 9,
                            CarImageURL = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.edmunds.com%2Fbmw%2Fx5%2F&psig=AOvVaw126ZB8ipJgwC5VWqTnrpkM&ust=1739651512091000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCOD6tIWBxIsDFQAAAAAdAAAAABAE",
                            Description = "The Audi A6 has 1 Petrol Engine on offer. \r\nThe Petrol engine is 1984 cc . It is available with Automatic transmission.\r\nDepending upon the variant and fuel type the A6 has a mileage of 14.11 kmpl & Ground clearance of A6 is 165 mm. \r\nThe A6 is a 5 seater 4 cylinder car and has length of 4939 mm,\r\n width of 2110 mm and a wheelbase of 2500 mm.",
                            FuelType = "gasoline",
                            HorsePower = 272,
                            Kilometers = 232000,
                            Model = "A6",
                            Price = 34500.00m,
                            UserId = "7cf7bb02-bad8-4cca-9a97-68ffec8ae0c0",
                            Year = 2015
                        });
                });

            modelBuilder.Entity("CarDealership.Data.Models.Dealership", b =>
                {
                    b.Property<int>("DealershipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DealershipId"), 1L, 1);

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DealershipId");

                    b.ToTable("Dealerships");

                    b.HasData(
                        new
                        {
                            DealershipId = 1,
                            Location = "London, United Kingdom",
                            Name = "Elite Motors"
                        },
                        new
                        {
                            DealershipId = 2,
                            Location = "Sydney, Australia",
                            Name = "Silverline Dealership"
                        },
                        new
                        {
                            DealershipId = 3,
                            Location = "Madrid, Spain",
                            Name = "Victory Wheels"
                        },
                        new
                        {
                            DealershipId = 4,
                            Location = "Dublin, Ireland",
                            Name = "Trusty Rides"
                        });
                });

            modelBuilder.Entity("CarDealership.Data.Models.DealershipsCars", b =>
                {
                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("DealershipId")
                        .HasColumnType("int");

                    b.HasKey("CarId", "DealershipId");

                    b.HasIndex("DealershipId");

                    b.ToTable("DealershipsCars");

                    b.HasData(
                        new
                        {
                            CarId = 1,
                            DealershipId = 1
                        },
                        new
                        {
                            CarId = 1,
                            DealershipId = 2
                        },
                        new
                        {
                            CarId = 2,
                            DealershipId = 3
                        },
                        new
                        {
                            CarId = 2,
                            DealershipId = 4
                        },
                        new
                        {
                            CarId = 3,
                            DealershipId = 1
                        },
                        new
                        {
                            CarId = 3,
                            DealershipId = 4
                        },
                        new
                        {
                            CarId = 4,
                            DealershipId = 3
                        },
                        new
                        {
                            CarId = 4,
                            DealershipId = 2
                        });
                });

            modelBuilder.Entity("CarDealership.Data.Models.GeneralManager", b =>
                {
                    b.Property<int>("GeneralManagerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GeneralManagerId"), 1L, 1);

                    b.Property<int>("DealershipId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("HireDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("GeneralManagerId");

                    b.HasIndex("DealershipId");

                    b.ToTable("GeneralManagers");

                    b.HasData(
                        new
                        {
                            GeneralManagerId = 1,
                            DealershipId = 1,
                            Email = "james.carter@email.com",
                            FirstName = "James",
                            HireDate = "08/04/2020",
                            LastName = "Carter",
                            PhoneNumber = "+44 7512 345678",
                            Salary = 5000.00m
                        },
                        new
                        {
                            GeneralManagerId = 2,
                            DealershipId = 2,
                            Email = "emily.johnson@email.com",
                            FirstName = "Emily",
                            HireDate = "11/11/2020",
                            LastName = "Johnson",
                            PhoneNumber = "+1 415-555-1234",
                            Salary = 3000.00m
                        },
                        new
                        {
                            GeneralManagerId = 3,
                            DealershipId = 3,
                            Email = "jrlucas.bennett@email.com",
                            FirstName = "Lucas",
                            HireDate = "28/02/2020",
                            LastName = "Bennett",
                            PhoneNumber = "+1 202-555-4321",
                            Salary = 10000.00m
                        },
                        new
                        {
                            GeneralManagerId = 4,
                            DealershipId = 4,
                            Email = "charlotte.robinson@email.com",
                            FirstName = "Charlotte",
                            HireDate = "21/06/2020",
                            LastName = "Robinson",
                            PhoneNumber = "+44 7700 987654",
                            Salary = 900000m
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "7cf7bb02-bad8-4cca-9a97-68ffec8ae0c0",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "92dd08a8-36c7-4c88-9077-a1f8e92200d5",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "TEST@SOFTUNI.BG",
                            PasswordHash = "AQAAAAEAACcQAAAAEFfDUzC9h2GZVs3bA2Y1ek40eIy0POlUYkVbAlGwA28f6pxzMm2Xlj9WXOveYx5/Ew==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "6be4c80a-5c45-4d32-ab8c-5b3ed560527a",
                            TwoFactorEnabled = false,
                            UserName = "GuestUser@gmail.com"
                        },
                        new
                        {
                            Id = "47aaf910-32bc-447d-a751-081c7121f7e7",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6f2ed0d6-47a9-4e58-a961-9f29fd05b25b",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@gmail.com",
                            NormalizedUserName = "admin@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEAWcYiHkyhRbt12kBVBg7JijXIqdQuZER4jXZZSCQKXp4EzMUjPZAiFSzb05IoAElA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "cba48ed0-6ccf-496f-886d-67ac50853d98",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CarDealership.Data.Models.Car", b =>
                {
                    b.HasOne("CarDealership.Data.Models.Brand", "Brand")
                        .WithMany("Cars")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarDealership.Data.Models.DealershipsCars", b =>
                {
                    b.HasOne("CarDealership.Data.Models.Car", "Car")
                        .WithMany("DealershipsCars")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarDealership.Data.Models.Dealership", "Dealership")
                        .WithMany("DealershipsCars")
                        .HasForeignKey("DealershipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Dealership");
                });

            modelBuilder.Entity("CarDealership.Data.Models.GeneralManager", b =>
                {
                    b.HasOne("CarDealership.Data.Models.Dealership", "Dealerships")
                        .WithMany("GeneralManagers")
                        .HasForeignKey("DealershipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dealerships");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarDealership.Data.Models.Brand", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarDealership.Data.Models.Car", b =>
                {
                    b.Navigation("DealershipsCars");
                });

            modelBuilder.Entity("CarDealership.Data.Models.Dealership", b =>
                {
                    b.Navigation("DealershipsCars");

                    b.Navigation("GeneralManagers");
                });
#pragma warning restore 612, 618
        }
    }
}
