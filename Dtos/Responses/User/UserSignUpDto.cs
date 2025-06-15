
namespace eShopApi.Dtos.Responses.User
{
    public class UserSignUpResponseDto
    {
        public Guid UserId { get; set; }
        public required string Username { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
    }
}