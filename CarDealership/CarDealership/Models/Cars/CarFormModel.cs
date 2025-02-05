using CarDealership.Models.Dealerships;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models.Cars
{
    public class CarFormModel
    {
        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        [Range(1886, 2025)]
        public int Year { get; set; }

        [Required]
        public string FuelType { get; set; }

        [Required]
        public string Kilometers { get; set; }

        [Required]
        [Range(1, 2000)]
        public int HorsePower { get; set; }

        [Required]
        [Range(0.01, 1000000)]
        public decimal Price { get; set; }

        [Required]
        [Url]
        public string CarImageURL { get; set; }

        [Required]
        public int DealershipId { get; set; }

        public IEnumerable<DealershipsModel> Dealerships { get; set; } = new List<DealershipsModel>();
    }
}
