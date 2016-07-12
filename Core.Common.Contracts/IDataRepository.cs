using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Contracts
{

    public interface IDataRepository
    {
    }

    public interface IDataRepository<T> : IDataRepository
        where T : class, new()
    {
        T Add(T entity);

        void Remove(T entity);

        void Remove(long id);

        T Update(T entity);

        IEnumerable<T> Get(Func<T, bool> filter);

        List<T> Get();

        T Get(long id);
    }
}
