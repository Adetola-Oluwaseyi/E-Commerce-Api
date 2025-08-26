
using E_Commerce.Api.Contracts;
using E_Commerce.Api.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Register([FromBody] UserDto user)
        {
            //if(!)

            var errors = await _authService.RegisterUser(user);

            if (errors.Any())
            {
                foreach (var item in errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }
                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Login([FromBody] LoginDto login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isValid = await _authService.LoginUser(login);

            if (isValid.Error is not null)
            {
                return Unauthorized(new { error = isValid.Error }); //for unauthenticated requests
                //return Forbid(); //for unathourized requests
            }

            if (isValid.Exception is not null)
            {
                return StatusCode(500, new { error = isValid.Exception });
            }

            return Ok(new { isValid.Token });


        }
    }
}
