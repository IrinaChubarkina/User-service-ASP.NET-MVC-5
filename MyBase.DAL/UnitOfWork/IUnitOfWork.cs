using System.Threading.Tasks;

namespace MyBase.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
