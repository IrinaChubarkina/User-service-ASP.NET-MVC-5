using MyBase.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBase.BLL.Services.UserService
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetListAsync(int listSize, int startFrom);
        Task CreateAsync(UserDTO userDto);
        Task<UserDTO> GetUserAsync(int id);
        Task EditAsync(UserDTO userDto);
        Task DeleteAsync(int id);
        void Dispose();
        Task<int> GetUsersCountAsync();
        Task FillStorageWithUsersAsync();
    }
}
