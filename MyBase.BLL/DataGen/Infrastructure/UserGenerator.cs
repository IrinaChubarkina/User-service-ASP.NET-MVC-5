using MyBase.DAL.Entities;
using MyBase.DAL.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MyBase.BLL.DataGen.Infrastructure
{
    public class UserGenerator : DataGenerator
    {
        IRepository<Contact> contactRepository;
        IRepository<Picture> pictureRepository;

        public UserGenerator(IRepository<Contact> cr, IRepository<Picture> pr)
        {
            contactRepository = cr;
            pictureRepository = pr;
        }
        protected override DataTable CreateTable()
        {
            var dataTable = new DataTable();
            string[] columns = new string[4] { "FirstName", "LastName", "ContactId", "PictureId" };
            foreach (var column in columns)
            {
                dataTable.Columns.Add(column);
            }
            return dataTable;
        }

        protected override void FillTable(DataTable dataTable, int recordsCount)
        {
            int contactLastId = contactRepository.GetLastId();
            int pictureLastId = pictureRepository.GetLastId();

            Random rnd = new Random();

            for (var i = 1; i <= recordsCount; i++)
            {
                DataRow row = dataTable.NewRow();
                row["FirstName"] = "Name_" + rnd.Next(10000, 99999);
                row["LastName"] = "Surname_" + rnd.Next(10000, 99999);
                row["ContactId"] = i + contactLastId;
                row["PictureId"] = i + pictureLastId;
                dataTable.Rows.Add(row);
            }
        }

        protected override void WriteToServer(DataTable dataTable, string connectionString)
        {
            using (var sqlBulk = new SqlBulkCopy(connectionString))
            {
                foreach (var column in dataTable.Columns) //только когда совпадают названия столбцов!
                {
                    sqlBulk.ColumnMappings.Add(column.ToString(), column.ToString());
                }

                sqlBulk.DestinationTableName = "Users";
                //sqlBulk.ColumnMappings.Add("FirstName", "FirstName");
                //sqlBulk.ColumnMappings.Add("LastName", "LastName");
                //sqlBulk.ColumnMappings.Add("ContactId", "ContactId");
                //sqlBulk.ColumnMappings.Add("PictureId", "PictureId");
                sqlBulk.WriteToServer(dataTable);
            }
        }
    }
}
