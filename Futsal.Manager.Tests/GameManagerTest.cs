using System.Linq;
using Core.Common.Contracts;
using Core.Common.Core;
using Futsal.Business.Bootstrapper;
using Futsal.Business.Managers.Games;
using Futsal.Data;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Futsal.Manager.Tests
{
    public class GameManagerTest
    {
        public GameManagerTest()
        {
            MsLoader.Init<FutsalDbContext>();
        }

        [Fact]
        public void Test_game_manager_create()
        {
            var unitOfWork = ObjectBase.MSContainer.GetRequiredService<IUnitOfWork>();
            var manager = new GameManager(unitOfWork);
            manager.CreateGame();
            var cnt = manager.GetAllGames().Count();

            Assert.Equal(1, cnt);
        }
    }
}