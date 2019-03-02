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
        public IEnumerable<User> GenerateData(int number, int initialId, int initialContactId, int initialPictureId)
        {
            List<User> list = new List<User>();
            for (int i = initialId + 1; i <= initialId + number; i++)
            {
                list.Add(new User()
                {
                    FirstName = $"Name-{i}",
                    LastName = $"Last name-{i}",
                    ContactId = i + initialContactId -  initialId,
                    PictureId = i + initialPictureId - initialId,
                    Contact = new Contact()
                    {
                        Email = $"Email-{i}",
                        PhoneNumber = $"Number-{i}"
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
