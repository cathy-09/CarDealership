using static CarDealership.Data.DataConstants.Employees;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Data.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(EmailMaxLength)]
        public string Email { get; set; }

        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        [Required]
        [Range((double)DataConstants.Employees.SalaryMin, (double)DataConstants.Employees.SalaryMax)]
        public decimal Salary { get; set; }

        public int DealershipId { get; set; }
        public Dealerships Dealerships { get; set; }
    }
}
