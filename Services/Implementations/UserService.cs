using AutoMapper;
using eShopApi.Dtos.Requests.User;
using eShopApi.Dtos.Responses.User;
using eShopApi.Models.Entities;
using eShopApi.Repositories.Interfaces;
using eShopApi.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace eShopApi.Services.Implementations
{
    public class UserService(IUserRepository userRepository, IMapper mapper, IPasswordHasher<User> passwordHasher) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IPasswordHasher<User> _passwordHasher = passwordHasher;


        // public async Task<UserSignUpRequestDto?> SignUpAsync([FromBody] UserSignUpRequestDto bodyContext)
        // {

        //     var user = new User
        //     {
        //         Username = bodyContext.Username,
        //         FirstName = bodyContext.FirstName,
        //         LastName = bodyContext.LastName,
        //         Email = bodyContext.Email,
        //         Password = string.Empty,
        //         FullName = $"{bodyContext.FirstName} {bodyContext.LastName}",
        //     };

        //     var hashedPassword = _passwordHasher.HashPassword(user, bodyContext.Password);
        //     user.Password = hashedPassword;

        //     await _userRepository.AddUserAsync(user);

        //     return MapUserToDto(user);
        // }
        public async Task<UserSignUpResponseDto?> SignUpAsync(UserSignUpRequestDto request)
        {
            var user = _mapper.Map<User>(request);
            user.Password = _passwordHasher.HashPassword(user, request.Password);
            user.FullName = $"{request.FirstName} {request.LastName}";

            // Add user to the database
            await _userRepository.AddUserAsync(user);
            var responseDto = _mapper.Map<UserSignUpResponseDto>(user);

            return responseDto;
        }
        public async Task<UserDto?> GetUserByUserIdAsync(Guid userId)
        {
            var user = await _userRepository.GetUserByUserIdAsync(userId);
            return user == null ? null : _mapper.Map<UserDto>(user);
        }

        // public async Task<UserDto?> GetUserByUsernameAsync(string username)
        // {
        //     var user = await _userRepository.GetUserByUsernameAsync(username);
        //     return user == null ? null : MapUserToDto(user);
        // }

        // public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        // {
        //     var users = await _userRepository.GetAllUsersAsync();
        //     return users.Select(u => MapUserToDto(u));
        // }

        // public async Task<UserDto?> UpdateUserAsync(int id, UserDto userDto)
        // {
        //     var existingUser = await _userRepository.GetUserByIdAsync(id);
        //     if (existingUser == null)
        //     {
        //         return null;
        //     }

        //     // Cập nhật các trường từ DTO. Không cập nhật mật khẩu ở đây.
        //     existingUser.Username = userDto.Username;
        //     existingUser.FirstName = userDto.FirstName;
        //     existingUser.LastName = userDto.LastName;
        //     existingUser.Email = userDto.Email;
        //     existingUser.FullName = $"{userDto.FirstName} {userDto.LastName}";
        //     existingUser.AvatarUrl = userDto.AvatarUrl;
        //     existingUser.DateOfBirth = userDto.DateOfBirth;
        //     existingUser.Phone = userDto.Phone;
        //     existingUser.Gender = userDto.Gender;
        //     existingUser.Address = userDto.Address;
        //     existingUser.UpdatedAt = DateTime.UtcNow;

        //     await _userRepository.UpdateUserAsync(existingUser);
        //     return MapUserToDto(existingUser);
        // }

        // public async Task<bool> DeleteUserAsync(int id)
        // {
        //     var user = await _userRepository.GetUserByIdAsync(id);
        //     if (user == null)
        //     {
        //         return false;
        //     }

        //     await _userRepository.DeleteUserAsync(id);
        //     return true;
        // }

        // public async Task<bool> ValidateUserPasswordAsync(string username, string password)
        // {
        //     var user = await _userRepository.GetUserByUsernameAsync(username);
        //     if (user == null)
        //     {
        //         return false;
        //     }

        //     var result = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
        //     return result == PasswordVerificationResult.Success;
        // }

        // // Helper method để chuyển đổi Entity sang DTO
        private static UserSignUpResponseDto MapUserToDto(UserSignUpRequestDto user)
        {
            return new UserSignUpResponseDto
            {
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
            };
        }
    }
}