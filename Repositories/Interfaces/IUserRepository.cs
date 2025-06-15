

using eShopApi.Models.Entities;

namespace eShopApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        // User Repository Interface 
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByUserIdAsync(Guid userId);
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByUsernameAsync(string username);
        Task<User?> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        // User Validations Repository 
        Task<bool> UserExistsAsync(string username);
        Task<bool> EmailExistsAsync(string email);
    }
}