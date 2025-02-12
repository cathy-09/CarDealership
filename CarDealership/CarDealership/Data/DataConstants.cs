namespace CarDealership.Data
{
    public class DataConstants
    {
        public class Cars 
        {
            public const int BrandMaxLength = 20;
            public const int ModelMaxLength = 20;
            public const int FuelTypeMaxLength = 10;
            public const int KilometersMaxLength = 10;
            public const int DescriptionMaxLength = 500;
            public const decimal PriceMin = 0.01m;
            public const decimal PriceMax = 1000000m;
        }
        public class Dealerships 
        {
            public const int NameMaxLength = 100;
            public const int LocationMaxLenght = 200;
        }
        public class Employees 
        {
            public const int FirstNameMaxLength = 50;
            public const int LastNameMaxLength = 50;
            public const int EmailMaxLength = 100;
            public const int PhoneNumberMaxLength = 15;
            public const decimal SalaryMin = 0.01m;
            public const decimal SalaryMax = 1000000m;
        }
        public class ApplicationUser
        {
            public const int UserFirstNameMaxLength = 12;
            public const int UserFirstNameMinLength = 1;

            public const int UserLastNameMaxLength = 15;
            public const int UserLastNameMinLength = 3;
        }
    }
}
