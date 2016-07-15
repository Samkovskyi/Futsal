using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Contracts;
using Futsal.Business.Entities;
using Futsal.Data.Contracts;

namespace Futsal.Business.Managers.Games
{
    public class GameManager: IManager<Game>, IGameManager
    {
        private IUnitOfWork _repositoryFactory;

        public GameManager(IUnitOfWork repositoryFactory)
        {
            if (repositoryFactory == null)
                throw new ArgumentException(nameof(_repositoryFactory));

            _repositoryFactory = repositoryFactory;
        }
        
        public Game CreateGame()
        {
            var gameRepo = _repositoryFactory.GetDataRepository<IGameRepository>();
            var game = gameRepo.Add(new Game
            {
                Name = "Game from GameManager"
            });
            _repositoryFactory.Complete();
            return game;
        }

        public IEnumerable<Game> GetAllGames()
        {
            var gameRepo = _repositoryFactory.GetDataRepository<IGameRepository>();
            return gameRepo.Get();
        }
    }
}
