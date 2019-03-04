using EntityFramework.Utilities;
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

        public int Count()
        {
            if (db.Pictures.Count() == 0)
                return 0;
            return db.Pictures.Max(x => x.Id);
        }

        public void InsertFakeData(IEnumerable<User> source)
        {
            EFBatchOperation.For(db, db.Pictures).InsertAll(source.Select(p => p.Picture));
        }

        public void Delete(int id)
        {
            Picture picture = db.Pictures.Find(id);
            if (picture != null)
                db.Pictures.Remove(picture);
        }

        public void Update(Picture picture)
        {
            db.Entry(picture).State = EntityState.Modified;
        }
    }
}
