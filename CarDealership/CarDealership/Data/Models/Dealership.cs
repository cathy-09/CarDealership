using System.ComponentModel.DataAnnotations;
using static CarDealership.Data.DataConstants.Dealerships;

namespace CarDealership.Data.Models
{
    public class Dealership
    {
        [Key]
        public int DealershipId { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(LocationMaxLenght)]
        public string Location { get; set; }

        public ICollection<DealershipsCars> DealershipsCars { get; set; } = new List<DealershipsCars>();
        public ICollection<Employee> Employees { get; set; }
    }
}
