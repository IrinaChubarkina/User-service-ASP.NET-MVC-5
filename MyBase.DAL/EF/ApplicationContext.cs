using MyBase.DAL.Entities;
using System.Data.Entity;

namespace MyBase.DAL.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationContext(string connectionString)
            : base(connectionString)
        {
        }
    }
}

