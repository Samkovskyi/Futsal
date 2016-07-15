using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Contracts;
using Core.Common.Core;
using Microsoft.EntityFrameworkCore;
using Autofac;
using Microsoft.Extensions.DependencyInjection;

namespace Futsal.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private FutsalDbContext _context;

        public UnitOfWork()
        {
            //_context = ObjectBase.MSContainer.GetService<FutsalDbContext>();
        }

        public UnitOfWork(FutsalDbContext context)
        {
            _context = context;
        }


        public Task CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }

        public T GetDataRepository<T>() where T : class, IDataRepository
        {
            return ObjectBase.MSContainer.GetRequiredService<T>();
            //return ObjectBase.Container.Resolve<T>(new NamedParameter("context", _context));
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            _context.Dispose();
            _context = new FutsalDbContext();
        }
    }
}
