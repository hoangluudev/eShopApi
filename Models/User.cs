using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopApi.Models
{
    public class User
    {
        public required int UserId { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}