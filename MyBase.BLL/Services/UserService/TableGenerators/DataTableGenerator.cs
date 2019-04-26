using System;
using System.Data;

namespace MyBase.BLL.Services.UserService.TableGenerators
{
    public static class DataTableGenerator
    {
        private static Random _random = new Random();

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

            for (var i = 1; i <= recordsCount; i++)
            {
                var row = dataTable.NewRow();
                row[FirstName] = GenerateFirstName();
                row[LastName] = GenerateLastName();
                row[PhoneNumber] = GeneratePhoneNumber();
                row[Email] = row[FirstName] + "@mail.ru";

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        private static string GenerateFirstName()
        {
            var names = new[] { "Irina", "Katya", "Darya", "Polina", "Liza" };
            var randomInteger = _random.Next(0, 4);

            return names[randomInteger];
        }

        private static string GenerateLastName()
        {
            var names = new[] { "Nice", "Popova", "Ivanova", "Chubarkina", "Bodrova" };
            var randomInteger = _random.Next(0, 4);

            return names[randomInteger];
        }

        private static string GeneratePhoneNumber()
        {
            var a = _random.Next(100, 999);
            var b = _random.Next(100, 999);
            var c = _random.Next(1000, 9999);

            return string.Join("-", a, b, c);
        }
    }
}
