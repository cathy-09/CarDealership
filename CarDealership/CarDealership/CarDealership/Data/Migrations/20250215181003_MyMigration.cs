using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealership.Data.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Dealerships",
                columns: table => new
                {
                    DealershipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealerships", x => x.DealershipId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CarImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Kilometers = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    HorsePower = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Cars_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneralManagers",
                columns: table => new
                {
                    GeneralManagerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HireDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DealershipId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralManagers", x => x.GeneralManagerId);
                    table.ForeignKey(
                        name: "FK_GeneralManagers_Dealerships_DealershipId",
                        column: x => x.DealershipId,
                        principalTable: "Dealerships",
                        principalColumn: "DealershipId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DealershipsCars",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false),
                    DealershipId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealershipsCars", x => new { x.CarId, x.DealershipId });
                    table.ForeignKey(
                        name: "FK_DealershipsCars_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DealershipsCars_Dealerships_DealershipId",
                        column: x => x.DealershipId,
                        principalTable: "Dealerships",
                        principalColumn: "DealershipId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2c2b663a-2125-4c84-8f72-6e7c09bb4a31", 0, "5f133456-ef37-415e-b590-0bd051c8a235", null, false, false, null, null, "GuestUser@gmail.com", "AQAAAAEAACcQAAAAEFR09sB2iYzZItPJGoFwlm606zpSv+7V2Zrj0Y1TQZ3zjaXSFsxEtN/sYMuOXtoMZQ==", null, false, "c205f87a-acda-4d85-8375-303a38aecb50", false, "GuestUser@gmail.com" },
                    { "5496f43d-eb26-46bc-a2c6-7156faf158ad", 0, "b5861449-fa02-4258-a6e3-fdf2f8cfffda", "admin@gmail.com", false, false, null, "admin@gmail.com", "admin@gmail.com", "AQAAAAEAACcQAAAAEDHs1ysIrutpUdLyBIBzoEzhfgNVbd4xhbOwKjhj7MeEJUB+wF40tqU2ENvDNJr7+Q==", null, false, "735b54b6-d5c4-4fd7-92b7-225f657d327e", false, "admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandId", "BrandName" },
                values: new object[,]
                {
                    { 1, "Skoda" },
                    { 2, "Alfa Romeo" },
                    { 3, "BMW" },
                    { 4, "Fiat" },
                    { 5, "Ford" },
                    { 6, "Honda" },
                    { 7, "Opel" },
                    { 8, "Audi" },
                    { 9, "Mercedes" },
                    { 10, "Nissan" },
                    { 11, "Volkswagen" },
                    { 12, "Toyota" }
                });

            migrationBuilder.InsertData(
                table: "Dealerships",
                columns: new[] { "DealershipId", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "London, United Kingdom", "Elite Motors" },
                    { 2, "Sydney, Australia", "Silverline Dealership" },
                    { 3, "Madrid, Spain", "Victory Wheels" },
                    { 4, "Dublin, Ireland", "Trusty Rides" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "BrandId", "CarImageURL", "Description", "FuelType", "HorsePower", "Kilometers", "Model", "Price", "UserId", "Year" },
                values: new object[,]
                {
                    { 1, 1, "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0b/Skoda_Octavia_II_silver_vr.jpg/1024px-Skoda_Octavia_II_silver_vr.jpg", "Production years: from 2004 to 2013\r\n Engine displacement: from 1197 cm3 / 73 cu-in to 1984 cm3 / 121.1 cu-in\r\n Horsepower: from 75 PS / 74 HP / 55 kW to 200 PS / 197 HP / 147 kW\r\n Length: 457.2 cm / 180 inches Width: 176.9 cm / 69.65 inches Height: 146.2 cm / 57.56 inches Wheelbase: 257.8 cm / 101.5 inches\r\n CO2 emissions: from 119 to 242 g/Km", "diesel", 105, 399138, "Octavia 2", 6500.00m, "2c2b663a-2125-4c84-8f72-6e7c09bb4a31", 2008 },
                    { 2, 3, "https://stimg.cardekho.com/images/carexteriorimages/930x620/BMW/X5-2023/10452/1688992642182/front-left-side-47.jpg", "The BMW X5 has 1 Diesel Engine and 1 Petrol Engine on offer.\r\n The Diesel engine is 2993 cc while the Petrol engine is 2998 cc.\r\n It is available with Automatic transmission.\r\nDepending upon the variant and fuel type the X5 has a mileage of 12 kmpl. The X5 is a 5 seater 6 cylinder car and has length of 4922 mm,\r\n width of 2004 mm and a wheelbase of 2975 mm.", "gasoline", 306, 206000, "X5", 22000.00m, "2c2b663a-2125-4c84-8f72-6e7c09bb4a31", 2011 },
                    { 3, 1, "https://www.tuning.bg/public/upload/gallery/extended/normal/sfa1.jpg", " Production years: from 2013 to 2016\r\n Engine displacement: from 1197 cm3 / 73 cu-in to 1984 cm3 / 121.1 cu-in\r\n Horsepower: from 86 PS / 85 HP / 63 kW to 220 PS / 217 HP / 162 kW\r\n Length: 465.9 cm / 183.43 inches Width: 181.4 cm / 71.42 inches Height: 146.1 cm / 57.52 inches Wheelbase: 268.6 cm / 105.75 inches\r\n Curb Weight: from 1215 kg / 2679 lbs to 1470 kg / 3241 lbs\r\n CO2 emissions: from 97 to 142 g/Km", "diesel", 110, 174000, "Octavia 3", 35000.00m, "2c2b663a-2125-4c84-8f72-6e7c09bb4a31", 2016 },
                    { 4, 8, "https://stimg.cardekho.com/images/carexteriorimages/930x620/Audi/A6/10552/1708935437947/front-left-side-47.jpg", "The Audi A6 has 1 Petrol Engine on offer. \r\nThe Petrol engine is 1984 cc . It is available with Automatic transmission.\r\nDepending upon the variant and fuel type the A6 has a mileage of 14.11 kmpl & Ground clearance of A6 is 165 mm. \r\nThe A6 is a 5 seater 4 cylinder car and has length of 4939 mm,\r\n width of 2110 mm and a wheelbase of 2500 mm.", "gasoline", 272, 232000, "A6", 34500.00m, "2c2b663a-2125-4c84-8f72-6e7c09bb4a31", 2015 }
                });

            migrationBuilder.InsertData(
                table: "GeneralManagers",
                columns: new[] { "GeneralManagerId", "DealershipId", "Email", "FirstName", "HireDate", "LastName", "PhoneNumber", "Salary" },
                values: new object[,]
                {
                    { 1, 1, "james.carter@email.com", "James", "08/04/2020", "Carter", "+44 7512 345678", 5000.00m },
                    { 2, 2, "emily.johnson@email.com", "Emily", "11/11/2020", "Johnson", "+1 415-555-1234", 3000.00m },
                    { 3, 3, "jrlucas.bennett@email.com", "Lucas", "28/02/2020", "Bennett", "+1 202-555-4321", 10000.00m },
                    { 4, 4, "charlotte.robinson@email.com", "Charlotte", "21/06/2020", "Robinson", "+44 7700 987654", 900000m }
                });

            migrationBuilder.InsertData(
                table: "DealershipsCars",
                columns: new[] { "CarId", "DealershipId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 1 },
                    { 3, 4 },
                    { 4, 2 },
                    { 4, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BrandId",
                table: "Cars",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_UserId",
                table: "Cars",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DealershipsCars_DealershipId",
                table: "DealershipsCars",
                column: "DealershipId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralManagers_DealershipId",
                table: "GeneralManagers",
                column: "DealershipId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DealershipsCars");

            migrationBuilder.DropTable(
                name: "GeneralManagers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Dealerships");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
