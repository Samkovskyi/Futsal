using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Features.Scanning;
using Core.Common.Contracts;
using Core.Common.Core;
using Futsal.Data;
using Futsal.Data.Contracts;
using Futsal.Data.DataRepositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Futsal.Business.Bootstrapper
{
    public class MsLoader
    {
        public static void InitService(IServiceCollection services)
        {
            var serviceCollection = RegisterServices(services);
            ObjectBase.MSContainer = serviceCollection.BuildServiceProvider();
        }

        public static void Init<T>()
            where T: DbContext
        {
            Init<T>(options => options.UseInMemoryDatabase());
        }

        public static void Init<T>(Action<DbContextOptionsBuilder> optionsAction = null)
           where T : DbContext
        {
            var serviceCollection = new ServiceCollection();
            RegisterServices(serviceCollection);
            serviceCollection.AddDbContext<T>(optionsAction);
            ObjectBase.MSContainer = serviceCollection.BuildServiceProvider();
        }

        private static IServiceCollection RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IStadiumRepository, StadiumRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            return services;
        }
    }
}
