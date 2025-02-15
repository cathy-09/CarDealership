using System.ComponentModel.DataAnnotations;
using static CarDealership.Data.DataConstants.Dealerships;

namespace CarDealership.Data.Models
{
    public class Dealership
    {
        public Dealership()
        {
            
        }
        public Dealership(string name,
            string location)
        {
            this.Name = name;
            this.Location = location;
        }

        [Key]
        public int DealershipId { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(LocationMaxLenght)]
        public string Location { get; set; }

        public ICollection<DealershipsCars> DealershipsCars { get; set; }
        public ICollection<GeneralManager> GeneralManagers { get; set; }
    }
}
