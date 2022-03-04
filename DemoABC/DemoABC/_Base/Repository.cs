using DemoABC.Base.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoABC.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public IQueryable<TEntity> Query => throw new NotImplementedException();

        public Task<List<TEntity>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
        public Task DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        Task<TEntity> IRepository<TEntity>.InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }
    }
}
