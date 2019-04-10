using MyBase.DAL.Entities;
using System.Data.Entity;

namespace MyBase.DAL.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Picture> Pictures { get; set; }

        static ApplicationContext()
        {              
            //Database.SetInitializer(new MyContextInitializer());
        }

        public ApplicationContext()
            : base("DefaultConnection")
        {            
        }

        class MyContextInitializer : DropCreateDatabaseAlways<ApplicationContext>
        {
        }
    }
}

