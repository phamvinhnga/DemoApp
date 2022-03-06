using DemoABC.Base.interfaces;
using DemoABC.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoABC.Base
{
    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : class where TPrimaryKey : struct
    {

        internal ApplicationDbContext _dbContext;
        internal DbSet<TEntity> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<TEntity>();
        }

        //protected readonly TContext context;

        public IQueryable<TEntity> Query => throw new NotImplementedException();

        public Task DeleteAsync(TPrimaryKey entity)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task<List<TEntity>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public Task UpdateAsync(TEntity entity)
        {
            return Task.Run(() => _dbContext.Update(entity));
        }

        public Task SaveAsync()
        {
            return Task.Run(() => _dbContext.SaveChangesAsync());
        }
    }
}
