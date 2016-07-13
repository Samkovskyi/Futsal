using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Futsal.Data;
using Futsal.Business.Entities;
using Microsoft.Extensions.DependencyInjection;
using Futsal.Business.Bootstrapper;
using Futsal.Data.DataRepositories;
using Futsal.Data.Contracts;

namespace Futsal.Tests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AutofacLoader.Init();
            Console.WriteLine("Hello");
            var unitOfWork = new UnitOfWork(new Tests.FutsalDbContext2());
            var gameRepo = unitOfWork.GetDataRepository<IGameRepository>();
           gameRepo.Add(new Game
            {
                Id = 3,
                Name = "CoolGame"
            });
            gameRepo.Add(new Game
            {
                Name = "New Cool Game"
            });
            unitOfWork.Complete();
            var game = gameRepo.Get(3);
            Console.WriteLine($"Game id {game.Id}");
            Console.WriteLine($"Games count {game.Name}");
            Console.WriteLine($"Games count {gameRepo.Get().Count}");

            // dbContext.
            Console.ReadKey();
            
        }
    }
}
