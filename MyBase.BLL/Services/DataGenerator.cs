using MyBase.BLL.Interfaces;
using MyBase.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBase.BLL.Services
{
    public class DataGenerator : IDataGenerator
    {
        public IEnumerable<User> GenerateData(int count, int initialId, int initialContactId, int initialPictureId)
        {
            List<User> list = new List<User>();
            for (int i = initialId + 1; i < initialId + count; i++)
            {
                list.Add(new User()
                {
                    FirstName = $"Name_{i}",
                    LastName = $"LastName_{i}",
                    ContactId = i + initialContactId - initialId,
                    PictureId = i + initialPictureId - initialId,
                    Contact = new Contact()
                    {
                        Email = $"Email_{i + initialContactId - initialId}",
                        PhoneNumber = $"Number_{i + initialContactId - initialId}"
                    },
                    Picture = new Picture()
                    {
                        //
                    }
                });
            }
            return list;
        }
}
}
