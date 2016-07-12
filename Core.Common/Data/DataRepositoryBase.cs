using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Core.Common.Data
{
    public abstract class DataRepositoryBase<T> : IDataRepository<T>
     where T : class, new()
    {
        protected DbContext _context;

        protected DataRepositoryBase(DbContext context)
        {
            _context = context;
        }
        public T Add(T entity)
        {
            return _context.Set<T>().Add(entity).Entity;
        }

        public void Remove(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public void Remove(long id)
        {
            var entity = Get(id);
            _context.Entry(entity).State = EntityState.Deleted;

        }

        public T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public IEnumerable<T> Get(Func<T, bool> filter)
        {
            return _context.Set<T>().Where(filter);
        }

        public List<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        public T Get(long id)
        {
            return _context.Set<T>().Find(id);
        }
    }
}
