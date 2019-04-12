using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBase.DAL.Interfaces
{
    public interface IUserRepository<TEntity> 
       where TEntity : class
    {
        void Create(TEntity item);
        void Update(TEntity item);
        Task<List<TEntity>> GetListOfUsersAsync(int listSize, int startFrom);
        Task<TEntity> GetUserAsync(int id);
        Task<int> GetCountOfUsersAsync();
        Task DeleteAsync(int id);
    }
}

