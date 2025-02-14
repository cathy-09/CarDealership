using CarDealership.Data.Models;

namespace CarDealership.Models.DealershipsCars
{
    public class DealershipsCarsViewModel
    {
        public int CarId { get; set; }
        public int DealershipId { get; set; }

        public List<Car> Cars { get; set; } = new List<Car>();
        public List<Dealership> Dealerships { get; set; } = new List<Dealership>();
    }
}
