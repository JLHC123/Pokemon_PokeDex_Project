using Microsoft.AspNetCore.Mvc;
using RandomStuff.Data;
using RandomStuff.Models;

namespace RandomStuff.Controllers
{
    public class PokemonController : ControllerBase
    {
        [HttpGet("GetPokemons")]
        public IActionResult GetPokemons()
        {
            PokemonContext _context = new PokemonContext();
            var pokemons = _context.pokemon.ToList();
            return Ok(pokemons);
        }

        [HttpPost("PostPokemon")]
        public IActionResult PostPokemon(Pokemon pokemon)
        {
            PokemonContext _context = new PokemonContext();
            _context.pokemon.Add(pokemon);
            _context.SaveChanges();
            return Ok(pokemon);
        }
    }
}
