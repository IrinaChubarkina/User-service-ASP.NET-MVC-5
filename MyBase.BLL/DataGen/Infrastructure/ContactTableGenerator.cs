using MyBase.BLL.DataGen.Interfaces;
using System;
using System.Data;

namespace MyBase.BLL.DataGen.Infrastructure
{
    public class ContactTableGenerator : ITableGenerator
    {
        public DataTable CreateTable(int recordsCount)
        {
            var dataTable = new DataTable("Contacts");

            var columns = new[] { "PhoneNumber", "Email" };
            foreach (var column in columns)
            {
                dataTable.Columns.Add(column);
            }

            var random = new Random();
            for (var i = 1; i <= recordsCount; i++)
            {
                var row = dataTable.NewRow();                
                row["PhoneNumber"] = random.Next(100000,999999);
                row["Email"] = random.Next(100,999) + "@mail.ru";

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }        
    }
}
