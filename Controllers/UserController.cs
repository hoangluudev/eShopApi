using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eShopApi.Data;
using eShopApi.Models;

namespace eShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<User>>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null)
            {
                return NotFound("User not found");
            }
            return Ok(user);
        }


        [HttpPost]
        public async Task<ActionResult<List<User>>> CreateUser(User requestContext)
        {
            _context.Users.Add(requestContext);          
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = requestContext.UserId }, requestContext);
        }

        [HttpPut]
        public async Task<ActionResult<List<User>>> UpdateUser(User requestContext)
        {
            var user = await _context.Users.FindAsync(requestContext.UserId);
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
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
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