using Microsoft.AspNetCore.Mvc;
using eShopApi.Services.Interfaces;
using eShopApi.Dtos.Requests.User;
using eShopApi.Dtos.Responses.User;
using FluentValidation;

namespace eShopApi.Controllers.V1
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IUserService userService, IValidator<UserSignUpRequestDto> validator) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        private readonly IValidator<UserSignUpRequestDto> validateUserSignUp = validator;

        [HttpPost("sign-up")]
        public async Task<ActionResult<UserSignUpResponseDto>> SignUp([FromBody] UserSignUpRequestDto requestBody)
        {
            var validationResults = await validateUserSignUp.ValidateAsync(requestBody);
            if (!validationResults.IsValid)
            {
                return BadRequest(validationResults.ToDictionary());
            }
            var newUserDto = await _userService.SignUpAsync(requestBody);

            return CreatedAtAction(nameof(GetUserById), new { id = newUserDto?.UserId }, newUserDto);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById([FromRoute] Guid id)
        {
            var user = await _userService.GetUserByUserIdAsync(id);
            if (user == null)
                return NotFound("User not found");
            return Ok(user);
        }
    }

}
