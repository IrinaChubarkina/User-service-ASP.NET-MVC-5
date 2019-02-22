using MyBase.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBase.DAL.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        //public DbSet<Picture> Pictures { get; set; }

        public ApplicationContext(string connectionString)
            : base(connectionString)
        {
        }
    }
}

