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

            for (var i = 1; i <= recordsCount; i++)
            {
                var row = dataTable.NewRow();
                row[FirstName] = Faker.Name.FirstName();
                row[LastName] = Faker.Name.LastName();
                row[PhoneNumber] = Faker.Phone.GetShortPhoneNumber();
                row[Email] = Faker.Name.FirstName() + "@mail.ru";

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }        
    }
}
