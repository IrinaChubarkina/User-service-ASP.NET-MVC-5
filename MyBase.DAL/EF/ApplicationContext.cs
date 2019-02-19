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

        //static ApplicationContext()
        //{
        //    Database.SetInitializer<ApplicationContext>(new StoreDbInitializer());
        //}
        public ApplicationContext(string connectionString)
            : base(connectionString)
        {
        }
    }

    //public class storedbinitializer : dropcreatedatabaseifmodelchanges<applicationcontext>
    //{
    //    protected override void seed(applicationcontext db)
    //    {
    //        db.users.add(new user { firstname = "irina", lastname = "nice" });
    //        db.users.add(new user { firstname = "roma", lastname = "nice" });
    //        db.savechanges();
    //    }
    //}
}

