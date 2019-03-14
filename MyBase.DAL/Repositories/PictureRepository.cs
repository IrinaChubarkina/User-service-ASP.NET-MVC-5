using MyBase.DAL.EF;
using MyBase.DAL.Entities;
using MyBase.DAL.Interfaces;
using System.Data.Entity;

namespace MyBase.DAL.Repositories
{
    public class PictureRepository : IRepository<Picture>
    {
        ApplicationContext _context;

        public PictureRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(Picture picture)
        {
            _context.Pictures.Add(picture);
        }

        public void Update(Picture picture)
        {
            _context.Entry(picture).State = EntityState.Modified;
        }
    }
}
