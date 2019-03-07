using MyBase.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBase.BLL.DataGen
{
    public abstract class DataGenerator
    {
        readonly string connectionString = ConfigurationManager.ConnectionString(); 

        public void GenerateData(int recordsCount)
        {
            var dataTable = CreateTable();
            FillTable(dataTable, recordsCount);
            WriteToServer(dataTable, connectionString);
        }
        protected abstract DataTable CreateTable();
        protected abstract void FillTable(DataTable dataTable, int recordsCount);
        protected abstract void WriteToServer(DataTable dataTable, string connectionString);
    }
}
