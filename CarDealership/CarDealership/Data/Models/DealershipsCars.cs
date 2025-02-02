using static CarDealership.Data.DataConstants;

namespace CarDealership.Data.Models
{
    public class DealershipsCars
    {
        public int DealershipId { get; set; }
        public Dealerships Dealerships { get; set; }

        public int CarId { get; set; }
        public Cars Cars { get; set; }
    }
}
