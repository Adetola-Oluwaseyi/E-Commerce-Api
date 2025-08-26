using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Api.Models.Users
{
    public class LoginDto
    {
        [EmailAddress]
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
