using MyBase.BLL.DTO;
using MyBase.BLL.Interfaces;
using MyBase.DAL.Entities;

namespace MyBase.BLL.Mappers
{
    public class UserMapper : IMapper<UserDTO, User>
    {
        public User Convert(UserDTO source)
        {
            return new User {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                ContactId = source.ContactId,
                PictureId = source.PictureId
            };
        }

        public UserDTO Convert(User source)
        {
            return new UserDTO {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,                
                PhoneNumber = source.Contact.PhoneNumber,
                Email = source.Contact.Email,
                Image  = source.Picture.Image,
                ContactId = source.ContactId,
                PictureId = source.PictureId              
            };
        }
    }
}

