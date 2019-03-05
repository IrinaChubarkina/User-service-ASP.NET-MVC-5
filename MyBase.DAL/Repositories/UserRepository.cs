using MyBase.DAL.EF;
using MyBase.DAL.Entities;
using MyBase.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBase.DAL.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        ApplicationContext db;

        public UserRepository(ApplicationContext context)
        {
            db = context;
        }
        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }

        public void Add(User user)
        {
            db.Users.Add(user);
        }

        public void Update(User user)
        {
            db.Entry(user).State = System.Data.Entity.EntityState.Modified;
        }

        public User Get(int id)
        {
            return db.Users
                .AsNoTracking()
                .Include(x => x.Contact)
                .Include(x => x.Picture)
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<User> GetList(int listSize, int startFrom)
        {
            return db.Users
                .AsNoTracking()
                .Include(u => u.Contact)
                .Include(u => u.Picture)
                .OrderBy(u => u.Id)
                .Skip(() => startFrom)
                .Take(() => listSize);
        }

        public void InsertFakeData(int number, string connectionString)
        {
            var dtContacts = new DataTable();
            dtContacts.Columns.Add("Id");
            dtContacts.Columns.Add("PhoneNumber", typeof(string));
            dtContacts.Columns.Add("Email", typeof(string));

            var dtPictures = new DataTable();
            dtPictures.Columns.Add("Id");
            dtPictures.Columns.Add("Name");
            dtPictures.Columns.Add("Image");

            var dtUsers = new DataTable();
            dtUsers.Columns.Add("Id");
            dtUsers.Columns.Add("FirstName");
            dtUsers.Columns.Add("LastName");
            dtUsers.Columns.Add("ContactId");
            dtUsers.Columns.Add("PictureId");

            for (var i = 1; i <=number; i++)
            {
                DataRow row = dtContacts.NewRow();
                row["Id"] = i;
                row["PhoneNumber"] = "PhoneNumber " + i;
                row["Email"] = "Email " + i;
                dtContacts.Rows.Add(row);

                row = dtPictures.NewRow();
                row["Id"] = i;
                row["Name"] = "Name " + i;
                row["Image"] = null;
                dtPictures.Rows.Add(row);

                row = dtUsers.NewRow();
                row["Id"] = i;
                row["FirstName"] = "FirstName " + i;
                row["LastName"] = "LastName" + i;
                row["ContactId"] =  i;
                row["PictureId"] = i;
                dtUsers.Rows.Add(row);
            }
            using (var sqlBulk = new SqlBulkCopy(connectionString))
            {
                sqlBulk.DestinationTableName = "Contacts";
                sqlBulk.WriteToServer(dtContacts);
                sqlBulk.DestinationTableName = "Pictures";
                sqlBulk.WriteToServer(dtPictures);
                sqlBulk.DestinationTableName = "Users";
                sqlBulk.WriteToServer(dtUsers);
            }
        }

        public int Count()
        {
            return db.Users.Count();
        }
    }
}

