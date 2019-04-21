﻿using System;
using System.Data;

namespace MyBase.BLL.Services.UserService.TableGenerators
{
    public static class DataTableGenerator
    {
        public static DataTable CreateUsersTable(int recordsCount)
        {
            var dataTable = new DataTable("Users");

            const string FirstName = "FirstName";
            const string LastName = "LastName";
            const string PhoneNumber = "PhoneNumber";
            const string Email = "Email";

            var columns = new[] { FirstName, LastName, PhoneNumber, Email };
            foreach (var column in columns)
            {
                dataTable.Columns.Add(column);
            }

            var random = new Random();
            for (var i = 1; i <= recordsCount; i++)
            {
                var row = dataTable.NewRow();
                row[FirstName] = "Name_" + random.Next(10000, 99999);
                row[LastName] = "Surname_" + random.Next(10000, 99999);
                row[PhoneNumber] = random.Next(100000, 999999);
                row[Email] = random.Next(100, 999) + "@mail.ru";

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }        
    }
}
