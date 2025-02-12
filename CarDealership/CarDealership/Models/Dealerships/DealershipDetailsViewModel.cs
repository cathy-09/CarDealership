using CarDealership.Models.Cars;

namespace CarDealership.Models.Dealerships
{
    public class DealershipDetailsViewModel
    {
        public int Id { get; init; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<AllCarsModel> Cars { get; set; } = new List<AllCarsModel>();
        public List<string> Employees { get; set; } = new List<string>();
    }
}
