using MyBase.DAL.EF;
using MyBase.DAL.Entities;
using MyBase.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBase.DAL.Repositories
{
    public class PictureRepository : IRepository<Picture>
    {
        private ApplicationContext db;

        public PictureRepository(ApplicationContext context)
        {
            db = context;
        }

        public void Add(Picture picture)
        {
            db.Pictures.Add(picture);
        }

        public void Delete(int id)
        {
            Picture picture = db.Pictures.Find(id);
            if (picture != null)
                db.Pictures.Remove(picture);
        }

        public void Edit(Picture picture)
        {
            db.Entry(picture).State = EntityState.Modified;
        }
    }
}
