using Autofac;
using Core.Common.Contracts;
using Core.Common.Core;
using Futsal.Data;
using Futsal.Data.Contracts;
using Futsal.Data.DataRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Futsal.Business.Bootstrapper
{
    public static class AutofacLoader
    {
        public static void Init()
        {
            ObjectBase.Container = InitBuilder().Build();
        }

        public static ContainerBuilder InitBuilder()
        {
            var builder = new ContainerBuilder();
            return RegisterServices(builder);
        }

        private static ContainerBuilder RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<GameRepository>().As<IGameRepository>();
            builder.RegisterType<StadiumRepository>().As<IStadiumRepository>();
            builder.RegisterType<TeamRepository>().As<ITeamRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            return builder;
        }
    }
}
