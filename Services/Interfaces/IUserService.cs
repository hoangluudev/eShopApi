using eShopApi.Dtos.Requests.User;
using eShopApi.Dtos.Responses.User;

namespace eShopApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserSignUpResponseDto?> SignUpAsync(UserSignUpRequestDto request);
        // Task<UserSignUpRequestDto?> SignUpAsync(UserSignUpRequestDto signUpDto);
        Task<UserDto?> GetUserByUserIdAsync(Guid userId);
        // Task<UserDto?> GetUserByUsernameAsync(string username);
        // Task<IEnumerable<UserDto>> GetAllUsersAsync();
        // Task<UserDto?> UpdateUserAsync(int id, UserDto userDto);
        // Task<bool> DeleteUserAsync(int id);
        // Task<bool> ValidateUserPasswordAsync(string username, string password);
    }
}