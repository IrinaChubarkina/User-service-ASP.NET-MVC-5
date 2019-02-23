using MyBase.DAL.EF;
using MyBase.DAL.Entities;
using MyBase.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            db.SaveChanges();
        }

        public void Edit(User user)
        {
            db.Entry(user).State = EntityState.Modified;
        }

        public User Get(int id)
        {
            //return _dbSet.Include(,).Find(id);
            return db.Users.Include(x => x.Contact).Include(x => x.Picture).ToList().Find(x => x.Id == id);
            //return db.Users.Include(x => x.Contact).FirstOrDefault(x => x.Id == id)
            // return db.Users.Include(x => x.Contact)......
            //return db.Users.Find(id);
        }

        public IEnumerable<User> GetList()
        {
            return db.Users.Include(u => u.Contact).Include(x => x.Picture);
            // return db.Users.ToList();
            // return _dbSet.ToList();            
        }

        /* public User Get<TProperty>(int id, Expression<Func<User, TProperty>> expression)
         {
             return db.Users.Include(expression).FirstOrDefault(x => x.Id == id);
         }*/
    }
}

