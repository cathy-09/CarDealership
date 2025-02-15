using CarDealership.Data.Models;
using CarDealership.Data;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models.GeneralManager
{
    public class GeneralManagerViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string HireDate { get; set; }
        public decimal Salary { get; set; }
        public int DealershipId { get; set; }
        public Dealership Dealerships { get; set; }
    }
}
