using MyBase.DAL.EF;
using MyBase.DAL.Entities;
using MyBase.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Update(User user)
        {
            db.Entry(user).State = System.Data.Entity.EntityState.Modified;
        }

        public User Get(int id)
        {
            return db.Users
                .AsNoTracking()
                .Include(x => x.Contact)
                .Include(x => x.Picture)
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<User> GetList(int listSize, int startFrom)
        {
            return db.Users
                .AsNoTracking()
                .Include(u => u.Contact)
                .Include(u => u.Picture)
                .OrderBy(u => u.Id)
                .Skip(() => startFrom)
                .Take(() => listSize);
        }
        
        public int Count()
        {            
            return db.Users.Count();
        }

        public int GetLastId()
        {
            throw new NotImplementedException();
        }
    }
}

