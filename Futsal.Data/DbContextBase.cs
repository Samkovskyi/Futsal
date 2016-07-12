using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Futsal.Business.Entities;
using Microsoft.EntityFrameworkCore;

namespace Futsal.Data
{
    public class DbContextBase: DbContext
    {
        public DbSet<Game> GamesSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasKey(g => g.Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Filename=./blog.db");
            optionsBuilder.UseInMemoryDatabase();
            
        }


    }
}
