using Microsoft.AspNetCore.Identity;

namespace CarDealership.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Employee Employee { get; set; }
    }
}
