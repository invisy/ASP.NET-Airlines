using System;
using System.Threading.Tasks;

namespace Airlines.ApplicationCore.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        TRepository GetRepository<TRepository>() where TRepository : IRepository;
        Task<bool> SaveChanges();
    }
}