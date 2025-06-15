using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eShopApi.Data;
using eShopApi.Models.Entities;

namespace eShopApi.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<User>>> GetUser([FromRoute] int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null)
            {
                return NotFound("User not found");
            }
            return Ok(user);
        }


        [HttpPost]
        public async Task<ActionResult<List<User>>> CreateUser([FromBody] User requestContext)
        {
            _context.Users.Add(requestContext);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = requestContext.UserId }, requestContext);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<User>>> UpdateUser([FromRoute] int id, [FromBody] User requestContext)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null)
            {
                return NotFound("User not found");
            }
            user.Username = requestContext.Username;
            user.Email = requestContext.Email;
            user.Password = requestContext.Password;

            await _context.SaveChangesAsync();
            var updatedUser = await _context.Users.FindAsync(requestContext.UserId);

            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> DeleteUser([FromRoute] int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null)
            {
                return NotFound("User not found");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok("Delete user successfully!");
        }
    }
}