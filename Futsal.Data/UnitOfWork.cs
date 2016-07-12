using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Contracts;
using Core.Common.Core;
using Microsoft.EntityFrameworkCore;
using Autofac;

namespace Futsal.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContextBase _context;

        public UnitOfWork() : this(new DbContextBase())
        {
        }

        public UnitOfWork(DbContextBase context)
        {
            _context = context;
        }


        public Task CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }

        public T GetDataRepository<T>() where T : class, IDataRepository
        {
            return ObjectBase.Container.Resolve<T>(new NamedParameter("context", _context));
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            _context.Dispose();
            _context = new DbContextBase();
        }
    }
}
