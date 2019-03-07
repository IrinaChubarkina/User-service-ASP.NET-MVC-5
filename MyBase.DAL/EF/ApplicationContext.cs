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
        public DbSet<Picture> Pictures { get; set; }

        static ApplicationContext()
        {              
            Database.SetInitializer<ApplicationContext>(new MyContextInitializer());
        }

        public ApplicationContext()
            : base("DefaultConnection")
        {
            
        }

        class MyContextInitializer : DropCreateDatabaseAlways<ApplicationContext>
        {
            //public override void InitializeDatabase(ApplicationContext context)
            //{
            //    base.InitializeDatabase(context);
            //    string connectionString = context.Database.Connection.ConnectionString;
            //}
        }
    }
}

