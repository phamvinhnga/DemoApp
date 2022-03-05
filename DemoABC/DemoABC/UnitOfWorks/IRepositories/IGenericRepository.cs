using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoABC.UnitOfWorks.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Update(T entity);
        bool Remove(int id);

        //async method
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task<bool> RemoveAsync(int id);        
    }
}
