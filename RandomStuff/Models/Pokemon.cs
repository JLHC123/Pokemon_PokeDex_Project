using System.Text.Json.Serialization;

namespace RandomStuff.Models
{
    public class Pokemon
    {
        public long PokemonId { get; set; }
        public string PokemonName { get; set; }
        [JsonIgnore]
        public ICollection<CapturedPokemon> CapturedPokemons { get; set; }
    }
}
