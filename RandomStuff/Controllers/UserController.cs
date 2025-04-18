using Microsoft.AspNetCore.Mvc;
using RandomStuff.Data;
using RandomStuff.Models;

namespace RandomStuff.Controllers
{
    public class UserController : ControllerBase
    {
        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            PokemonContext _context = new PokemonContext();
            var users = _context.user.ToList();
            return Ok(users);
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser(User user)
        {
            PokemonContext _context = new PokemonContext();
            _context.user.Add(user);
            _context.SaveChanges();
            return Ok();
        }
    }
}
