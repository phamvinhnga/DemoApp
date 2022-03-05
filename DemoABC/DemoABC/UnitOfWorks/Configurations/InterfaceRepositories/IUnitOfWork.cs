using System;
using System.Threading.Tasks;

namespace DemoABC.UnitOfWorks.Configurations.InterfaceRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChange();
        Task<int> SaveChangeAsync();
    }
}
