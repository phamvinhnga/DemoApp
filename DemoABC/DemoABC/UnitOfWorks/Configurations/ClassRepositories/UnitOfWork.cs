using DemoABC.UnitOfWorks.Configurations.InterfaceRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DemoABC.UnitOfWorks.Configurations.ClassRepositories
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        protected readonly TContext context;
        public void Dispose()
        {
            context.Dispose();
        }
        public virtual ValueTask DisposeAsync()
        {
            return context.DisposeAsync();
        }
        public int SaveChange()
        {
            try
            {
                return context.SaveChanges();
            }
            catch (Exception ex)
            {                
                return 0;
            }
        }

        public Task<int> SaveChangeAsync()
        {
            try
            {
                return context.SaveChangesAsync();
            }
            catch (Exception ex)
            {                
                return Task.FromResult(0);
            }
        }
    }
}
