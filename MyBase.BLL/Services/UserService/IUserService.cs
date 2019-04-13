using MyBase.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBase.BLL.Services.UserService
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetListOfUsersAsync(int listSize, int startFrom);
        Task<int> CreateUserAsync(UserDTO userDto);
        Task<UserDTO> GetUserAsync(int id);
        Task UpdateUserAsync(UserDTO userDto);
        Task DeleteUserAsync(int id);
        void Dispose();
        Task<int> GetCountOfUsersAsync();
        Task FillStorageWithUsersAsync();
    }
}
