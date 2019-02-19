using MyBase.BLL.DTO;
using MyBase.BLL.Interfaces;
using MyBase.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBase.BLL.Mappers
{
    public class ContactMapper : IMapper<UserDTO, Contact>
    {
        public Contact ConvertToDownLayer(UserDTO source)
        {
            return new Contact
            {
                Id = source.ContactId,
                PhoneNumber = source.PhoneNumber,
                // Email = source.Contact.Email
                Email = source.Email
            };
        }

        public UserDTO ConvertToUpLayer(Contact source) // не надо
        {
            throw new NotImplementedException();
        }
    }
}
