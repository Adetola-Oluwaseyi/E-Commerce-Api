using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Api.Data
{
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
