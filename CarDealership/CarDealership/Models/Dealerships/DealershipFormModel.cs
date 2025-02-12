using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models.Dealerships
{
    public class DealershipFormModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Location { get; set; }
    }
}
