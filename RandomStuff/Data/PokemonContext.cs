using Microsoft.EntityFrameworkCore;
using RandomStuff.Models;

namespace RandomStuff.Data
{
    public class PokemonContext : DbContext
    {
        public String ConnectionString = "Data Source=LAPTOP-E849FIKF;Initial Catalog=Pokemon;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public DbSet<Pokemon> pokemon { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<CapturedPokemon> capturedPokemon { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CapturedPokemon>()
                .HasOne(cp => cp.User)
                .WithMany(u => u.CapturedPokemons)
                .HasForeignKey(cp => cp.UserId);

            modelBuilder.Entity<CapturedPokemon>()
                .HasOne(cp => cp.Pokemon)
                .WithMany(p => p.CapturedPokemons)
                .HasForeignKey(cp => cp.PokemonId);
        }
    }
}
