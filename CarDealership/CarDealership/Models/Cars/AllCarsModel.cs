using CarDealership.Data.Models;
using CarDealership.Data;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models.Cars
{
    public class AllCarsModel
    {
        public int CarId { get; init; }
        public string CarImageURL { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string FuelType { get; set; }
        public string Kilometers { get; set; }
        public int HorsePower { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
