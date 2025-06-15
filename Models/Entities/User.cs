
namespace eShopApi.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public Guid UserId { get; set; } = Guid.NewGuid();
        public required string Username { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? FullName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string? AvatarUrl { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? Phone { get; set; }
        public string? Gender { get; set; }
        public string[]? Address { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}