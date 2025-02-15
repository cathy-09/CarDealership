using System.ComponentModel.DataAnnotations;
using static CarDealership.Data.DataConstants.Brands;

namespace CarDealership.Data.Models
{
    public class Brand
    {
        public Brand()
        {

        }
        public Brand(string name)
        {
            this.BrandName = name;
        }
        [Key]
        public int BrandId { get; set; }

        [Required]
        [MaxLength(BrandMaxLength)]
        public string BrandName { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
