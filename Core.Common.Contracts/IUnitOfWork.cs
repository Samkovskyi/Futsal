using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Contracts
{
    public interface IUnitOfWork
    {
        void Complete();
        Task CompleteAsync();
        void Rollback();
        T GetDataRepository<T>() where T : class, IDataRepository;
    }
}
