using System;
using System.Data;
using System.Data.SqlClient;

namespace MyBase.BLL.DataGen.Infrastructure
{
    public class PictureGenerator : DataGenerator
    {
        protected override DataTable CreateTable()
        {
            var dataTable = new DataTable();
            string[] columns = new string[2] { "Name", "Image" };
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
                row["Name"] = "Image_" + rnd.Next(10000, 99999);
                row["Image"] = null;
                dataTable.Rows.Add(row);
            }
        }

        protected override void WriteToServer(DataTable dataTable, string connectionString)
        {
            using (var sqlBulk = new SqlBulkCopy(connectionString))
            {
                sqlBulk.DestinationTableName = "Pictures";
                //sqlBulk.ColumnMappings.Add("Name", "Name");
                //sqlBulk.ColumnMappings.Add("Image", "Image");
                foreach (var column in dataTable.Columns)
                {
                    sqlBulk.ColumnMappings.Add(column.ToString(), column.ToString());
                }
                sqlBulk.WriteToServer(dataTable);
            }
        }
    }
}
