using CarDealership.Models.Dealerships;

namespace CarDealership.Models.Employees
{
    public class EmployeeFormModel
    {
        public EmployeeFormModel()
        {
        }

        public IEnumerable<DealershipsModel> Dealerships { get; set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string Email { get; internal set; }
        public string PhoneNumber { get; internal set; }
        public DateTime HireDate { get; internal set; }
        public decimal Salary { get; internal set; }
        public int DealershipId { get; internal set; }
        public string UserId { get; internal set; }
    }
}