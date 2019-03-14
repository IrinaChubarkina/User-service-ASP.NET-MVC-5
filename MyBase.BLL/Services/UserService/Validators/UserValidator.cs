using MyBase.BLL.DTO;
using MyBase.BLL.Infrastructure.Helpers;
using System;

namespace MyBase.BLL.Infrastructure
{
    public class UserValidator 
    {
        public void ValidateAndThrow(UserDTO user)
        {
            if (user.FirstName.IsEmpty() ||
                user.LastName.IsEmpty() ||
                user.PhoneNumber.IsEmpty() ||
                user.Email.IsEmpty())
            {
                throw new Exception("Не все поля заполнены");
            }
        }
    }
}
