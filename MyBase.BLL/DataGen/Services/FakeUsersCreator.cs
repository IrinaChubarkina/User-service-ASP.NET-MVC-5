using MyBase.BLL.DataGen.Infrastructure;
using MyBase.BLL.DataGen.Interfaces;
using MyBase.BLL.Infrastructure;
using System.Data.SqlClient;

namespace MyBase.BLL.DataGen.Services
{
    public class FakeUsersCreator : IFakeUsersCreator
    {
        public void CreateFakeUsers()
        {
            var connectionString = ConfigurationManager.ConnectionString();

            var generators = new ITableGenerator[] {
                new UserTableGenerator(),
                new ContactTableGenerator()
            };

            var recordsCount = 100 * 1000;
            foreach (var generator in generators)
            {
                var dataTable = generator.CreateTable(recordsCount);

                using (var sqlBulk = new SqlBulkCopy(connectionString))
                {
                    sqlBulk.DestinationTableName = dataTable.TableName;

                    foreach (var column in dataTable.Columns)
                    {
                        sqlBulk.ColumnMappings.Add(column.ToString(), column.ToString());
                    }
                    sqlBulk.WriteToServer(dataTable);
                }
            }
        }
    }
}

