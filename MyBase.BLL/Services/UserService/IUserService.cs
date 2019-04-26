using MyBase.BLL.Services.UserService.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBase.BLL.Services.UserService
{
    public interface IUserService
    {
        Task<List<UserDto>> GetUsersAsync(int listSize, int startFrom);
        Task<int> CreateUserAsync(UserDto userDto);
        Task<UserDto> GetUserByIdAsync(int id);
        Task UpdateUserAsync(UserDto userDto);
        Task DeleteUserByIdAsync(int id);
        Task<int> GetUsersCountAsync();
        Task FillStorageWithFakeUsersAsync();
    }
}
