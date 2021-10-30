using System;
using System.Threading.Tasks;
using TaskManagement.DataAccess.Interfaces;

namespace TaskManagement.DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        Task CommitAsync();
    }
}
