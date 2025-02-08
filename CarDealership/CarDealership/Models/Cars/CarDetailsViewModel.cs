namespace CarDealership.Models.Cars
{
    public class CarDetailsViewModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string FuelType { get; set; }
        public string Kilometers { get; set; }
        public int HorsePower { get; set; }
        public decimal Price { get; set; }
        public string CarImageURL { get; set; }
        public string Description { get; set; }
        public List<string> Dealerships { get; set; } = new List<string>();
    }
}
