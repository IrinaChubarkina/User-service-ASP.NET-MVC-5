using MyBase.BLL.DataGen.Interfaces;
using MyBase.DAL.EF;
using System;
using System.Data;
using System.Linq;

namespace MyBase.BLL.DataGen.Infrastructure
{
    public class UserTableGenerator : ITableGenerator
    {
        public DataTable CreateTable(int recordsCount)
        {
            var dataTable = new DataTable("Users");

            var columns = new[] { "FirstName", "LastName", "ContactId"};
            foreach (var column in columns)
            {
                dataTable.Columns.Add(column);
            }

            var context = new ApplicationContext();
            var contactLastId = context.Contacts.Count() != 0 ? context.Contacts.Max(x => x.Id) : 0;

            var random = new Random();
            for (var i = 1; i <= recordsCount; i++)
            {
                var row = dataTable.NewRow();
                row["FirstName"] = "Name_" + random.Next(10000, 99999);
                row["LastName"] = "Surname_" + random.Next(10000, 99999);
                row["ContactId"] = i + contactLastId;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}
