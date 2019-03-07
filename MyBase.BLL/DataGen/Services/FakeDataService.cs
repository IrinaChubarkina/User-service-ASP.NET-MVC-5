using MyBase.BLL.DataGen.Infrastructure;
using MyBase.DAL.Entities;
using MyBase.DAL.Interfaces;

namespace MyBase.BLL.DataGen
{
    public class FakeDataService : IFakeDataService
    {
        readonly IRepository<Contact> contactRepository;
        readonly IRepository<Picture> pictureRepository;

        public FakeDataService(IRepository<Contact> cr, IRepository<Picture> pr)
        {
            contactRepository = cr;
            pictureRepository = pr;
        }

        public void InsertData(int recordsCount)
        {
            new UserGenerator(contactRepository, pictureRepository).GenerateData(recordsCount);
            new ContactGenerator().GenerateData(recordsCount);
            new PictureGenerator().GenerateData(recordsCount);
        }
    }
}

