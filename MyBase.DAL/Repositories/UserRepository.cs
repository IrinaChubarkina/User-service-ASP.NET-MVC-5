using MyBase.DAL.EF;
using MyBase.DAL.Entities;
using MyBase.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework.Extensions;

namespace MyBase.DAL.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        ApplicationContext db;

        public UserRepository(ApplicationContext context)
        {
            //EntityFrameworkManager.BulkOperationBuilder = builder => builder.BatchSize = 30000;
            db = context;
        }
        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }

        public void Add(User user)
        {
            db.Users.Add(user);
        }

        public void Edit(User user)
        {
            db.Entry(user).State = EntityState.Modified;
        }

        public User Get(int id)
        {
            return db.Users.Include(x => x.Contact).Include(x => x.Picture).ToList().Find(x => x.Id == id);            
        }

        public IEnumerable<User> GetList()
        {
            return db.Users.Include(u => u.Contact).Include(x => x.Picture);          
        }

        public void CreateFakeData()
        {
            db.BulkInsert(Data(), options => options.IncludeGraph = true);
            //Task[] tasks1 = new Task[2]
            //{
            //    new Task(() => db.BulkInsert(Data(), options => options.IncludeGraph = true)),
            //    new Task(() => db.BulkInsert(Data(), options => options.IncludeGraph = true))
            //};
            //foreach (var t in tasks1)
            //    t.Start();
            //Task.WaitAll(tasks1); 
        }

        public static List<User> Data()
        {
            List<User> list = new List<User>();

            for (int i = 0; i < 1000; i++)
            {
                list.Add(new User()
                {
                    FirstName = $"Name {i}",
                    LastName = $"Last name {i}",
                    Contact = new Contact()
                    {
                        Email = $"Email {i}",
                        PhoneNumber = $"Number {i}"
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

