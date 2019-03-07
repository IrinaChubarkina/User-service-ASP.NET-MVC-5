using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyBase.BLL.DataGen
{
    public class FirstTableCreator
    {
        public DataTable GetTable(Type type, int recordsCount)
        {
            var dataTable = CreateTable(type);
            FillTable(dataTable, type, recordsCount);
            return dataTable;
        }

        protected virtual DataTable CreateTable(Type type)
        {
            var dataTable = new DataTable();
            foreach (PropertyInfo prop in type.GetProperties())
            {
                dataTable.Columns.Add(prop.Name);
            }
            return dataTable;
        }

        protected virtual void FillTable(DataTable dataTable, Type type, int recordsCount)
        {
            Random rnd = new Random();
            for (var i = 1; i <= recordsCount; i++)
            {
                DataRow row = dataTable.NewRow();
                foreach (PropertyInfo prop in type.GetProperties())
                {
                    if (prop.GetType() == typeof(string))
                    {
                        row[prop.Name] = prop.Name + rnd.Next(0, 1000);
                    }
                    else if (prop.GetType() == typeof(int))
                    {
                        row[prop.Name] = i;
                    }
                    else
                        row[prop.Name] = null;
                }
                //row["Id"] = i;
                dataTable.Rows.Add(row);
            }
        }
    }
}
