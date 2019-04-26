using System.IO;
using System.Security.Policy;

namespace MyBase.DAL.FileStorage
{
    public interface IFileStorage
    {
        Url SaveFile(Stream stream, string fileName);
    }
}
