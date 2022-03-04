using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoABC.Base.interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Query { get; }

        Task<List<TEntity>> GetListAsync();

        Task<TEntity> InsertAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task Save();
    }
}
