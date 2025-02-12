using CarDealership.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models.Dealerships
{
    public class AllDealershipsModel
    {
        public int DealershipId { get; init; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<string> Cars { get; set; } = new List<string>();

        public List<string> Employees { get; set; } = new List<string>();
    }
}
