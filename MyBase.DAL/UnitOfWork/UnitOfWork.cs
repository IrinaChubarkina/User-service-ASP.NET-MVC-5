using MyBase.DAL.EF;
using MyBase.DAL.Interfaces;
using System;
using System.Threading.Tasks;

namespace MyBase.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }        

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}