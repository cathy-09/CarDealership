using CarDealership.Data.Models;

namespace CarDealership.Models.Cars
{
    public class CarSearchViewModel
    {
        public string BrandName { get; set; }
        public List<Car> Cars { get; set; }
    }
}
