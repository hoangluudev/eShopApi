
namespace eShopApi.Models.Entities
{
    public class Role
    {
        public required int RoleId { get; set; }
        public required string Name { get; set; }
        public string[]? Permission { get; set; }
    }
}