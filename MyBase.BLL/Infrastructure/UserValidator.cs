using MyBase.BLL.DTO;
using MyBase.BLL.Interfaces;

namespace MyBase.BLL.Infrastructure
{
    public class UserValidator : IUserValidator
    {
        public bool Check(UserDTO user)
        {
            if (user.FirstName == null || user.LastName == null || user.PhoneNumber == null || user.Email == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
