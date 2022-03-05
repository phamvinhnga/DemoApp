using DemoABC.Base.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoABC.Base
{
    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : IEntity<TPrimaryKey> where TPrimaryKey : struct
    {
        public IQueryable<TEntity> Query => throw new NotImplementedException();

        public Task DeleteAsync(TPrimaryKey entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
