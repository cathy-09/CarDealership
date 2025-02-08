namespace CarDealership.Models.Cars
{
    public class EditCarsModel : CarFormModel
    {
        public int CarId { get; init; }
        public string Description { get; set; }
    }
}
