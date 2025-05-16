using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomStuff.Data;
using RandomStuff.Models;

namespace RandomStuff.Controllers
{
    public class CapturedPokemonController : ControllerBase
    {
        [HttpGet("GetAllCapturedPokemon")]
        public IActionResult GetAllCapturedPokemon()
        {
            PokemonContext _context = new PokemonContext();
            var allCapturedPokemon = _context.capturedPokemon
                .Include(cp => cp.Pokemon)
                .Include(cp => cp.User)
                .ToList();
            return Ok(allCapturedPokemon);
        }

        [HttpGet("GetUserCapturedPokemon")]
        public IActionResult GetUserCapturedPokemon(long UserId)
        {
            PokemonContext _context = new PokemonContext();
            var user = _context.user.Find(UserId);
            if (user == null)
            {
                return NotFound($"User with ID {UserId} not found.");
            }
            var userCapturedPokemon = _context.capturedPokemon
                .Where(cp => cp.UserId == UserId)
                .OrderBy(cp => cp.CapturedPokemonId)
                .Include(cp => cp.Pokemon)
                .ToList();
            return Ok(userCapturedPokemon);
        }
    }
}
