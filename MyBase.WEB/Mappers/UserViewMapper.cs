using MyBase.BLL.DTO;
using MyBase.BLL.Interfaces;
using MyBase.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBase.WEB.Mappers
{
    public class UserViewMapper : IMapper<UserViewModel, UserDTO>
    {
        public UserDTO ConvertToDownLayer(UserViewModel source)
        {
            return new UserDTO
            {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                PhoneNumber = source.PhoneNumber,
                Email = source.Email,
                ContactId = source.Id, //по-моему ето нехорошо
            };
        }

        public UserViewModel ConvertToUpLayer(UserDTO source)
        {
            return new UserViewModel
            {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                PhoneNumber = source.PhoneNumber,
                Email = source.Email,
                ContactId = source.ContactId,
            };
        }
    }
}