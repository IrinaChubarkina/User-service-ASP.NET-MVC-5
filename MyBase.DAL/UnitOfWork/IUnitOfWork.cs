using System;
using System.Threading.Tasks;

namespace MyBase.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync();
    }
}
