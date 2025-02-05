using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models.Dealerships
{
    public class DealershipsModel
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
