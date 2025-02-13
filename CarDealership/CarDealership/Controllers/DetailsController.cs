using Microsoft.AspNetCore.Mvc;

namespace CarDealership.Controllers
{
    public class DetailsController : Controller
    {
        // Action to display car details
        public IActionResult Index(int id)
        {
            // Simulate fetching car details from a database or service
            var car = GetCarDetailsById(id);

            if (car == null)
            {
                return NotFound(); // Return a 404 error if the car is not found
            }

            return View(car); // Pass the car object to the view
        }

        // Helper method to simulate fetching car details
        private Car GetCarDetailsById(int id)
        {
            // Simulated data - replace this with actual database logic
            var cars = new List<Car>
            {
                new Car { Id = 1, Brand = "Tesla", Model = "Model 3", Year = 2022, FuelType = "Electric", KilometersDriven = 15000, Horsepower = 279, Dealership = "Tesla", Price = 45000, ImageUrl = "https://dreamcars77.com/wp-content/uploads/Tesla-Model-4-Long-Range-4x4-EU-34.jpg", Description = "The Tesla Model 3 is a sleek and modern electric sedan designed for efficiency and performance." },
                new Car { Id = 2, Brand = "Porsche", Model = "911", Year = 2021, FuelType = "Petrol", KilometersDriven = 10000, Horsepower = 443, Dealership = "Porsche", Price = 120000, ImageUrl = "https://cdn.motor1.com/images/mgl/7ZvGj/s1/porsche-911-turbo-s.jpg", Description = "The Porsche 911 is a legendary sports car known for its performance and timeless design." }
            };

            return cars.FirstOrDefault(c => c.Id == id);
        }
    }