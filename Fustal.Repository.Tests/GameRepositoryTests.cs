using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Futsal.Business.Entities;
using Futsal.Data;
using Futsal.Data.DataRepositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using Fustal.Repository.Tests.Extensions;
using FluentAssertions;

namespace Fustal.Repository.Tests
{
    public class GameRepositoryTests
    {
        private GameRepository _gameRepo;
        private Mock<DbSet<Game>> _mockGames;

        public GameRepositoryTests()
        { 
            _mockGames = new Mock<DbSet<Game>>();

            var mockContext = new Mock<TestDbContext>();
            mockContext.Setup(c => c.Set<Game>()).Returns(_mockGames.Object);

            _gameRepo = new GameRepository(mockContext.Object);
        }

        [Fact]
        public void Get_GameNotExist_ShouldNotBeReturn()
        {
            var game = new Game
            {
                Id = 1,
                Name = "New Game"
            };
            _mockGames.SetSource(new[] {game});
            var result = _gameRepo.Get(2);
            result.Should().BeNull();

        }

        [Fact]
        public void GetByFilter_ValidRequest_ShouldReturn()
        {
            var game = new Game
            {
                Id = 1,
                Name = "New Game"
            };
            _mockGames.SetSource(new[] { game });
            var result = _gameRepo.Get(x => x.Id == 1);
            result.Should().NotBeNull();
            result.Should().Contain(x => x.Id== 1);
        }

        public class TestDbContext: FutsalDbContext
        {
            public TestDbContext():base(new DbContextOptions<FutsalDbContext>())
            {
                
            }
            
        }
    }
}
