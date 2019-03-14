using System.Collections.Generic;
using MyBase.BLL.DTO;
using MyBase.DAL.Entities;

namespace MyBase.BLL.Services.UserService.Mappers
{
    public class UserMapper : IUserMapper<User, UserDTO>
    {
        public User Map(UserDTO source)
        {
            var user = new User {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                ContactId = source.ContactId,
                PictureId = source.PictureId
            };
            if (source.Image == null)
            {
                //user.PictureId = null;
            }
            return user;
        }

        public UserDTO Map(User source)
        {
            var userDTO = new UserDTO {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,                
                PhoneNumber = source.Contact.PhoneNumber,
                Email = source.Contact.Email,
                ContactId = source.ContactId,
                PictureId = source.PictureId
            };
            if (source.Picture != null)
            {
                userDTO.Image = source.Picture.Image;
                //userDTO.PictureId = source.PictureId.Value;
            }
            return userDTO;
        }

        public List<UserDTO> Map(List<User> source)
        {
            var usersDto = new List<UserDTO>();
            foreach (var item in source)
            {
                usersDto.Add(Map(item));
            }

            return usersDto;
        }
    }
}

