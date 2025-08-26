namespace E_Commerce.Api.Models.Users
{
    public class UserDto : LoginDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
