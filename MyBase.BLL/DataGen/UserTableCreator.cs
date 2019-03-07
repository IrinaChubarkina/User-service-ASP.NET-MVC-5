using MyBase.DAL.Entities;
using MyBase.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyBase.BLL.DataGen
{
    public class UserTableCreator : FirstTableCreator
    {
        IRepository<Contact> contactRepository;
        IRepository<Picture> pictureRepository;

        public UserTableCreator( IRepository<Contact> cr, IRepository<Picture> pr)
        {
            contactRepository = cr;
            pictureRepository = pr;
        }


        protected override DataTable CreateTable(Type type)
        {
            var dataTable = new DataTable();
            foreach (PropertyInfo prop in type.GetProperties())
            {
                if (prop.Name!="Contact" && prop.Name!="Picture")
                {
                    dataTable.Columns.Add(prop.Name);
                }
                //dataTable.Columns.AddRange()
            }
            return dataTable;
        }

        protected override void FillTable(DataTable dataTable, Type type, int recordsCount)
        {
            int contactLastId = contactRepository.Count();
            int pictureLastId = pictureRepository.Count();

            Random rnd = new Random();
            for (var i = 1; i <= recordsCount; i++)
            {
                DataRow row = dataTable.NewRow();
                //foreach (PropertyInfo prop in type.GetProperties())
                //{
                //    if (prop.GetType() == typeof(string))
                //    {
                //        row[prop.Name] = prop.Name + rnd.Next(0, 1000);
                //    }
                //    else if (prop.GetType() == typeof(int))
                //    {
                //        row[prop.Name] = i;
                //    }
                //    else
                //        row[prop.Name] = null;
                //    //if (prop.Name != "Id")
                //    //{
                //    //    row[prop.Name] = prop.Name + rnd.Next(0, 1000);
                //    //}
                //}
                row["Id"] = i;
                row["FirstName"] = "hjk";
                row["LastName"] = "hjk";

                row["ContactId"] = i + contactLastId;
                row["PictureId"] = i + pictureLastId;

                dataTable.Rows.Add(row);
            }
        }
    }
}
