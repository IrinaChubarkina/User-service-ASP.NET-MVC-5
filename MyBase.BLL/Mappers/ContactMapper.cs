using MyBase.BLL.DTO;
using MyBase.BLL.Mappers;
using MyBase.DAL.Entities;

namespace MyBase.BLL.Mappers
{
    public class ContactMapper : IMapper<UserDTO, Contact>
    {
        public Contact Map(UserDTO source)
        {
            return new Contact {
                Id = source.ContactId,
                PhoneNumber = source.PhoneNumber,
                Email = source.Email
            };
        }
    }
}
