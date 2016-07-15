using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Futsal.Business.Entities;
using Futsal.Data.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Futsal.Data
{
    public class FutsalDbContext: IdentityDbContext<AppUser>
    {
        public FutsalDbContext(DbContextOptions<FutsalDbContext> options) : base(options)
        {
        }
        public FutsalDbContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Team> Teams { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(GameConfiguration.GetTypeBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
