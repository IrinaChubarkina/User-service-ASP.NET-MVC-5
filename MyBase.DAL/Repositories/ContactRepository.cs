using MyBase.DAL.EF;
using MyBase.DAL.Entities;
using MyBase.DAL.Interfaces;
using System.Data.Entity;

namespace MyBase.DAL.Repositories
{
    public class ContactRepository : IRepository<Contact>
    {
        private ApplicationContext db;

        public ContactRepository(ApplicationContext context)
        {
            db = context;
        }

        public void Create(Contact contact)
        {
            db.Contacts.Add(contact);
        }

        public void Update(Contact contact)
        {
            db.Entry(contact).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact != null)
                db.Contacts.Remove(contact);
        }
    }
}