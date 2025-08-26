using E_Commerce.Api.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Api.Contracts
{
    public interface IAuthService
    {
        Task<ResponseDto> LoginUser(LoginDto login);
        Task<IEnumerable<IdentityError>> RegisterUser(UserDto user);
    }
}
