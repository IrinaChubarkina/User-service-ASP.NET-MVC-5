using MyBase.BLL.Infrastructure;
using MyBase.DAL.Entities;
using MyBase.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyBase.BLL.DataGen
{
    public class DataGenerator : IDataGenerator
    {
        IRepository<Contact> contactRepository;
        IRepository<Picture> pictureRepository;
        string connectionString = ConfigurationManager.ConnectionString();

        public DataGenerator(IRepository<Contact> cr, IRepository<Picture> pr)
        {
            contactRepository = cr;
            pictureRepository = pr;
        }

        public void GenerateData(int recordsCount)
        {
            FirstTableCreator tableCreator = new FirstTableCreator();
            var contactTable = tableCreator.GetTable(typeof(Contact), recordsCount);
            var pictureTable = tableCreator.GetTable(typeof(Picture), recordsCount);

            UserTableCreator userTableCreator = new UserTableCreator(contactRepository, pictureRepository);
            var userTable = userTableCreator.GetTable(typeof(User), recordsCount);

            //using (var connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();

            //    var transaction = connection.BeginTransaction();

            //    using (var sqlBulk = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction))
            //    {
            //        sqlBulk.DestinationTableName = "Contacts";
            //        sqlBulk.WriteToServer(contactTable);
            //        sqlBulk.DestinationTableName = "Pictures";
            //        sqlBulk.WriteToServer(pictureTable);
            //        sqlBulk.DestinationTableName = "Users";
            //        sqlBulk.WriteToServer(userTable);
            //    }
            //}

            using (var sqlBulk = new SqlBulkCopy(connectionString)) //стратегия паттерн , шевчук
            {

                sqlBulk.DestinationTableName = "Contacts";
                sqlBulk.WriteToServer(contactTable);

                //sqlBulk.DestinationTableName = "Pictures";
                //sqlBulk.WriteToServer(dtPictures);
                sqlBulk.DestinationTableName = "Users";
                sqlBulk.WriteToServer(userTable);
            }


        }

        //using (var sqlBulk = new SqlBulkCopy(connectionString)) //стратегия паттерн , шевчук
        //{

        //    sqlBulk.DestinationTableName = "Contacts";
        //    sqlBulk.WriteToServer(contactsTable);

        //    //sqlBulk.DestinationTableName = "Pictures";
        //    //sqlBulk.WriteToServer(dtPictures);
        //    //sqlBulk.DestinationTableName = "Users";
        //    //sqlBulk.WriteToServer(dtUsers);
        //}
        //void WriteToServer()
        //{

        //}
    }
}

