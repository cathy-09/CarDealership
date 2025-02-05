using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static CarDealership.Data.DataConstants;

namespace CarDealership.Data.Models
{
    public class DealershipsCars
    {
        [Required]
        public int CarId { get; set; }

        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; }

        [Required]
        public int DealershipId { get; set; }

        [ForeignKey(nameof(DealershipId))]
        public Dealership Dealership { get; set; }
    }
}
