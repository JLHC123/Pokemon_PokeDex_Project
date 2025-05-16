using Microsoft.AspNetCore.Mvc;
using RandomStuff.Data;
using RandomStuff.Models;

namespace RandomStuff.Controllers
{
    public class AuthController : ControllerBase
    {
        [HttpPost("Register")]
        public IActionResult Register(string UserName, string Password, string Email)
        {
            PokemonContext _context = new PokemonContext();
            if (_context.user.Any(u => u.UserName == UserName))
            {
                return BadRequest(new { message = "Username already exists!" });
            }
            if (_context.user.Any(u => u.Email == Email))
            {
                return BadRequest(new { message = "Email already exists!" });
            }
            var newUser = new User
            {
                UserName = UserName,
                Password = Password,
                Email = Email
            };
            _context.user.Add(newUser);
            _context.SaveChanges();
            return Ok(new { message = "User registered successfully!" });
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] User login)
        {
            PokemonContext _context = new PokemonContext();
            var user = _context.user.FirstOrDefault(u => u.UserName == login.UserName && u.Password == login.Password);
            if (user == null)
            {
                return BadRequest(new { message = "Invalid username or password!" });
            }
            return Ok(new { message = "Login successful!", userId = user.UserId });
        }
    }
}
