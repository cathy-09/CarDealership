using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models.Employees
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
        public string DealershipName { get; set; }
    }
}
