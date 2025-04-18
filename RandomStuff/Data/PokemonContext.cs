using Microsoft.EntityFrameworkCore;
using RandomStuff.Models;

namespace RandomStuff.Data
{
    public class PokemonContext : DbContext
    {
        public String ConnectionString = "Data Source=CS-19;Initial Catalog=Pokemon;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public DbSet<Pokemon> pokemon { get; set; }
        public DbSet<User> user { get; set; }
    }
}
