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
        public IEnumerable<User> GenerateData(int number, int initialContactId, int initialPictureId)
        {
            List<User> list = new List<User>();
            for (int i = 1; i <= number; i++)
            {
                list.Add(new User()
                {
                    FirstName = $"Name",
                    LastName = $"Last name",
                    ContactId = i + initialContactId,
                    PictureId = i + initialPictureId,
                    Contact = new Contact()
                    {
                        Email = $"Email",
                        PhoneNumber = $"Number"
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
