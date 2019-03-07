using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBase.BLL.DataGen
{
    public class ContactTableCreator : TableCreator
    {
        protected override DataTable CreateTable()
        {
            throw new NotImplementedException();
        }

        protected override void FillTable(DataTable dataTable, int recordsCount)
        {
            throw new NotImplementedException();
        }

        protected override void WriteToServer(DataTable dataTable, string connectionString)
        {
            throw new NotImplementedException();
        }
    }
}
