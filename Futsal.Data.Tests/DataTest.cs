using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common.Core;
using Futsal.Business.Bootstrapper;
using Futsal.Business.Entities;
using Futsal.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Futsal.Data.Tests
{
    public class DataTest
    {
        public DataTest()
        {
            AutofacLoader.Init();
        }

        [Fact]
        public void Test_game_repo_add()
        {
            var unitOfWork = new UnitOfWork(new TestDbContext());
            var gameRepo = unitOfWork.GetDataRepository<IGameRepository>();
            gameRepo.Add(new Game
            {
                Name = "TestGame"
            });
            
            unitOfWork.Complete();
            var gameFromRepo = gameRepo.Get(1);
            var game = new Game
            {
                Id = 1,
                Name = "TestGame"
            };

            Assert.Equal(game.Id, gameFromRepo.Id);
            Assert.Equal(game.Name, gameFromRepo.Name);

            Assert.Equal(1,gameRepo.Get().Count);
        }

        internal class TestDbContext : FutsalDbContext
        {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                //optionsBuilder.UseSqlite("Filename=./blog.db");
                optionsBuilder.UseInMemoryDatabase();
            }
        }

    }
}
