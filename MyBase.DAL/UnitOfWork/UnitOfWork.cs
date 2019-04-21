using MyBase.DAL.EF;
using System.Threading.Tasks;

namespace MyBase.DAL.UnitOfWork
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
    }
}