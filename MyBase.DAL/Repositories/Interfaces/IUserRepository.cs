using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBase.DAL.Interfaces
{
    public interface IUserRepository<TEntity> : IRepository<TEntity>
       where TEntity : class
    {
        Task<List<TEntity>> GetListAsync(int listSize, int startFrom);
        Task<TEntity> GetUserAsync(int id);
        Task<int> GetUsersCountAsync();
        Task DeleteAsync(int id);
    }
}

