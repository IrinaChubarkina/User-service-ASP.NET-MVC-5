using EntityFramework.Utilities;
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
            return db.Users
                .AsNoTracking()
                .Include(x => x.Contact)
                .Include(x => x.Picture)
                .ToList()
                .Find(x => x.Id == id);
        }

        public IEnumerable<User> GetList()
        {

            //var result = db.Users
            //    .IncludeEFU(db, u => u.Contact)
            //    .ToList();

            return db.Users
                .Include(u => u.Contact)
                .Include(x => x.Picture)
                .AsNoTracking();


        }

        public void InsertFakeData(IEnumerable<User> source)
        {            
            EFBatchOperation.For(db, db.Users).InsertAll(source);
        }       

        public int Count()
        {            
            if (db.Users.Count() == 0)
                return 0;
            return db.Users.Max(x => x.Id);
        }
    }
}

