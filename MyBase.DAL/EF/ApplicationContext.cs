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

        static ApplicationContext()
        {
            Database.SetInitializer<ApplicationContext>(new StoreDbInitializer());
        }
        public ApplicationContext(string connectionString)
            : base(connectionString)
        {
        }
    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationContext>
    {
        protected override void Seed(ApplicationContext db)
        {
            db.Users.Add(new User { FirstName = "Nokia Lumia 630", LastName = "Nokia" });
            db.Users.Add(new User { FirstName = "iPhone 6", LastName = "Apple" });
            db.Users.Add(new User { FirstName = "LG G4", LastName = "lG" });
            db.Users.Add(new User { FirstName = "Samsung Galaxy S 6", LastName = "Samsung" });
            db.SaveChanges();
        }
    }
}

