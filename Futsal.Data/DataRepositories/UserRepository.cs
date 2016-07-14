using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Data;
using Futsal.Business.Entities;
using Futsal.Data.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Futsal.Data.DataRepositories
{
    public class UserRepository : DataRepositoryBase<AppUser>, IUserRepository
    {
        public UserRepository(FutsalDbContext context) : base(context)
        {
        }
    }
}
