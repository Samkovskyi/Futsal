using Futsal.Business.Entities;
using Futsal.Data;
using Futsal.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Futsal.Tests
{
    public class FutsalDbContext2: FutsalDbContext
    {
        public DbSet<Game> GamesSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(GameConfiguration.GetTypeBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./blog.db");
            //optionsBuilder.UseInMemoryDatabase();
        }
    }
}
