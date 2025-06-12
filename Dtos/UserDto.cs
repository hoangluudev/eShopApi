using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopApi.Dtos
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

    }
}