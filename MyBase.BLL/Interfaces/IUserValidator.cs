using MyBase.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBase.BLL.Interfaces
{
    public interface IUserValidator
    {
        bool Check(UserDTO user);
    }
}
