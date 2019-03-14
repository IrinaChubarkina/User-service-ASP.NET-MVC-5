using MyBase.DAL.EF;
using MyBase.DAL.Entities;
using MyBase.DAL.Interfaces;
using System.Data.Entity;

namespace MyBase.DAL.Repositories
{
    public class ContactRepository : IRepository<Contact>
    {
        ApplicationContext _context;

        public ContactRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(Contact contact)
        {
            _context.Contacts.Add(contact);
        }

        public void Update(Contact contact)
        {
            _context.Entry(contact).State = EntityState.Modified;
        }
    }
}