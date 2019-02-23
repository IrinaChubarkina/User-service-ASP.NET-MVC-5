﻿using MyBase.DAL.EF;
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

        public void Add(Contact contact)
        {
            db.Contacts.Add(contact);
        }

        public void Edit(Contact contact)
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