using System.Text.Json.Serialization;

namespace RandomStuff.Models
{
    public class CapturedPokemon
    {
        public long CapturedPokemonId { get; set; }
        public string Nickname { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public long PokemonId { get; set; }
        public Pokemon Pokemon { get; set; }
        
    }
}
