using MyBase.BLL.DTO;

namespace MyBase.BLL.Interfaces
{
    public interface IUserValidator
    {
        bool Check(UserDTO user);
    }
}
