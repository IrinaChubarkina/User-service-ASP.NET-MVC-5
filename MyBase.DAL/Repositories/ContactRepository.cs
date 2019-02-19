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
    public class ContactRepository : IRepository<Contact>
    {
        private ApplicationContext db;

        public ContactRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public IEnumerable<Contact> GetList() //не надо
        {
            return db.Contacts;
        }

        public Contact Get(int id) //не надо
        {
            return db.Contacts.Find(id);
        }

        public void Add(Contact book)
        {
            db.Contacts.Add(book);
        }

        public void Edit(Contact book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Contact book = db.Contacts.Find(id);
            if (book != null)
                db.Contacts.Remove(book);
        }

        /*public Contact Get<TProperty>(int id, Expression<Func<Contact, TProperty>> expression)
        {
            throw new NotImplementedException();
        }*/
    }
}