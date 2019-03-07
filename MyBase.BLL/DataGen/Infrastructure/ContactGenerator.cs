using System;
using System.Data;
using System.Data.SqlClient;

namespace MyBase.BLL.DataGen
{
    public class ContactGenerator : DataGenerator
    {
        protected override DataTable CreateTable()
        {
            var dataTable = new DataTable();
            //string[] columns = new string[3] {"Id", "PhoneNumber", "Email" };
            string[] columns = new string[2] { "PhoneNumber", "Email" };
            foreach (var column in columns)
            {
                dataTable.Columns.Add(column);
            }
            return dataTable;
        }

        protected override void FillTable(DataTable dataTable, int recordsCount)
        {
            Random rnd = new Random();
            for (var i = 1; i <= recordsCount; i++)
            {
                DataRow row = dataTable.NewRow();                
                //row["Id"] = i;
                row["PhoneNumber"] = rnd.Next(100000,999999);
                row["Email"] = rnd.Next(100,999) + "@mail.ru";
                dataTable.Rows.Add(row);
            }
        }

        protected override void WriteToServer(DataTable dataTable, string connectionString)
        {
            using (var sqlBulk = new SqlBulkCopy(connectionString)) 
            {
                sqlBulk.DestinationTableName = "Contacts";
                //sqlBulk.ColumnMappings.Add("PhoneNumber", "PhoneNumber");
                //sqlBulk.ColumnMappings.Add("Email", "Email");
                foreach (var column in dataTable.Columns)
                {
                    sqlBulk.ColumnMappings.Add(column.ToString(), column.ToString());
                }
                sqlBulk.WriteToServer(dataTable);
            }
        }
    }
}
