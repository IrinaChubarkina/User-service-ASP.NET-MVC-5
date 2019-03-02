using MyBase.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBase.BLL.Interfaces
{
    public interface IDataGenerator
    {
        IEnumerable<User> GenerateData(int count, int initialContactId, int initialPictureId);
    }
}
