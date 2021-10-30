using System.Threading.Tasks;
using TaskManagement.DataAccess.Context;
using TaskManagement.DataAccess.Interfaces;
using TaskManagement.DataAccess.Repositories;

namespace TaskManagement.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskContext _context;
        public UnitOfWork(TaskContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_context);
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
