using CarDealership.Data.Models;

namespace CarDealership.Models.Cars
{
    public class CarCreateViewModel
    {
        public string Model { get; set; }
        public string CarImageURL { get; set; }
        public int Year { get; set; }
        public string FuelType { get; set; }
        public int Kilometers { get; set; }
        public int HorsePower { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int BrandId { get; set; }
        public List<Brand> Brands { get; set; } = new List<Brand>();
    }
}
