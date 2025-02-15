using CarDealership.Data.Models;
using CarDealership.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models.Cars
{
    public class CarViewModelass
    {
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public string Model { get; set; }
        public string CarImageURL { get; set; }
        public int Year { get; set; }
        public string FuelType { get; set; }
        public int Kilometers { get; set; }
        public int HorsePower { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
