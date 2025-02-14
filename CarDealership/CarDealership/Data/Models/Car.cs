using Humanizer.Localisation;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using static CarDealership.Data.DataConstants.Cars;

namespace CarDealership.Data.Models
{
    public class Car
    {
        public Car()
        {

        }
        public Car(int brandId,
            string model,
            string carURL,
            int year,
            string fuelType,
            int kilometeres,
            int horsePower,
            string description, 
            decimal price
            )
        {
            this.BrandId = brandId;
            this.Model = model;
            this.CarImageURL = carURL;
            this.Year = year;
            this.FuelType = fuelType;
            this.Kilometers = kilometeres;
            this.HorsePower = horsePower;
            this.Description = description;
            this.Price = price;
        }

        [Key]
        public int CarId { get; set; }

        [Required]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        [Required]
        [MaxLength(ModelMaxLength)]
        public string Model { get; set; }
        
        [Required]
        [Url]
        public string CarImageURL { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [MaxLength(FuelTypeMaxLength)]
        public string FuelType { get; set; }

        [Required]
        [MaxLength(KilometersMaxLength)]
        public int Kilometers { get; set; }

        [Required]
        public int HorsePower { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [Range((double)DataConstants.Cars.PriceMin, (double)DataConstants.Cars.PriceMax)]
        public decimal Price { get; set; }

        [Required]
        public string UserID { get; set; } = null!;
        public IdentityUser User { get; set; } = null!;

        public ICollection<DealershipsCars> DealershipsCars { get; set; }
    }
}
