using MyBase.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBase.DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void Create(User user);
        void Update(User user);
        Task<List<User>> GetAllNotDeletedUsersAsync(int listSize, int startFrom);
        Task<User> GetByIdAsync(int id);
        Task DeleteByIdAsync(int id);
        Task<int> NotDeletedUsersCountAsync();
    }
}

