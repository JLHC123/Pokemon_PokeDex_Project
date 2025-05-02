using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomStuff.Data;

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
    }
}
