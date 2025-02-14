using static CarDealership.Data.DataConstants.Employees;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CarDealership.Data.Models
{
    public class GeneralManager
    {
        public GeneralManager()
        {
            
        }
        public GeneralManager(string firstName, 
            string lastName, 
            string email, 
            string phoneNumber, 
            string hireDate, 
            decimal salary, 
            int dealershipId)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.HireDate = hireDate;
            this.Salary = salary;
            this.DealershipId = dealershipId;
        }
        [Key]
        public int GeneralManagerId { get; set; }

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
        public string HireDate { get; set; }

        [Required]
        [Range((double)DataConstants.Employees.SalaryMin, (double)DataConstants.Employees.SalaryMax)]
        public decimal Salary { get; set; }

        public int DealershipId { get; set; }
        public Dealership Dealerships { get; set; }
    }
}
