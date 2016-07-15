using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common.Contracts;
using Core.Common.Core;
using Futsal.Business.Bootstrapper;
using Futsal.Business.Entities;
using Futsal.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Futsal.Data.Tests
{
    public class DataTest
    {
        public DataTest()
        {
            AutofacLoader.Init();
            MsLoader.Init<FutsalDbContext>();
        }

        [Fact]
        public void Test_game_repo_add()
        {
            IUnitOfWork unitOfWork = ObjectBase.MSContainer.GetRequiredService<IUnitOfWork>();
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
       

    }
}
