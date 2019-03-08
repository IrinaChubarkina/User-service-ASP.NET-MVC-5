﻿using MyBase.BLL.DTO;
using MyBase.BLL.Interfaces;
using MyBase.DAL.Entities;
using System;

namespace MyBase.BLL.Mappers
{
    public class ContactMapper : IMapper<UserDTO, Contact>
    {
        public Contact Convert(UserDTO source)
        {
            return new Contact {
                Id = source.ContactId,
                PhoneNumber = source.PhoneNumber,
                Email = source.Email
            };
        }

        public UserDTO Convert(Contact source) 
        {
            throw new NotImplementedException();
        }
    }
}
