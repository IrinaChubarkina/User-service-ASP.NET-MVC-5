using MyBase.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBase.BLL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetList();
        void Add(UserDTO userDto);
        UserDTO Get(int id);
        void Edit(UserDTO userDto);
        void Delete(int id);
        void Dispose();
        void CreateFakeData();
    }
}
