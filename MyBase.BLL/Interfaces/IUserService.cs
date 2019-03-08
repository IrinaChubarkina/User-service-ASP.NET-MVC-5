using MyBase.BLL.DTO;
using System.Collections.Generic;

namespace MyBase.BLL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetList(int listSize, int startFrom);
        void Create(UserDTO userDto);
        UserDTO GetUser(int id);
        void Edit(UserDTO userDto);
        void Delete(int id);
        void Dispose();
        int GetUsersCount();
    }
}
