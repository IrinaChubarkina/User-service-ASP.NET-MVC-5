using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBase.DAL.Interfaces
{
    public interface IUserRepository<TEntity> : IRepository<TEntity>
       where TEntity : class
    {
        Task<List<TEntity>> GetListOfUsersAsync(int listSize, int startFrom);
        Task<TEntity> GetUserAsync(int id);
        Task<int> GetCountOfUsersAsync();
        Task DeleteAsync(int id);
    }
}

