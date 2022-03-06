using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoABC.Base.interfaces
{
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : class where TPrimaryKey : struct
    {
        IQueryable<TEntity> Query { get; }

        Task<TEntity> GetAsync(TPrimaryKey id);

        Task<List<TEntity>> GetListAsync();

        Task<TEntity> InsertAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TPrimaryKey entity);

        Task SaveAsync();
    }
}
