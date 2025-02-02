using Microsoft.VisualBasic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static CarDealership.Data.DataConstants.Cars;

namespace CarDealership.Data.Models
{
    public class Cars
    {
        [Key]
        public int CarId { get; set; }

        [Required]
        public string CarImageURL { get; set; }

        [Required]
        [MaxLength(BrandMaxLength)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(ModelMaxLength)]
        public string Model { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [MaxLength(FuelTypeMaxLength)]
        public string FuelType { get; set; }

        [Required]
        [MaxLength(KilometersMaxLength)]
        public string Kilometers { get; set; }

        [Required]
        public int HorsePower { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [Range((double)DataConstants.Cars.PriceMin, (double)DataConstants.Cars.PriceMax)]
        public decimal Price { get; set; }

        public ICollection<DealershipsCars> DealershipsCars { get; set; }
    }
}
