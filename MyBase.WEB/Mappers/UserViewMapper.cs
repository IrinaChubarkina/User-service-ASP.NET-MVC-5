using MyBase.BLL.DTO;
using MyBase.BLL.Services.UserService.Mappers;
using MyBase.WEB.Models;
using System.Collections.Generic;
using System.IO;

namespace MyBase.WEB.Mappers
{
    public class UserViewMapper : IUserMapper<UserDTO, UserViewModel>
    {
        public UserDTO Map(UserViewModel source)
        {
            if (source.File != null)
            using (var binaryReader = new BinaryReader(source.File.InputStream))
            {
                source.Image = binaryReader.ReadBytes(source.File.ContentLength);
            }
            return new UserDTO
            {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                PhoneNumber = source.PhoneNumber,
                Email = source.Email,
                ContactId = source.ContactId,
                Image = source.Image,
                PictureId = source.PictureId
            };

        }

        public UserViewModel Map(UserDTO source)
        {
            return new UserViewModel
            {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                PhoneNumber = source.PhoneNumber,
                Email = source.Email,
                Image = source.Image,

                ContactId = source.ContactId,
                PictureId = source.PictureId
            };
        }

        public List<UserViewModel> Map(List<UserDTO> source)
        {
            var users = new List<UserViewModel>();
            foreach (var item in source)
            {
                users.Add(Map(item));
            }

            return users;
        }
    }
}