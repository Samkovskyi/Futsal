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
    public class StadiumRepository : DataRepositoryBase<Stadium>, IStadiumRepository
    {
        public StadiumRepository(FutsalDbContext context) : base(context)
        {
        }
    }
}
