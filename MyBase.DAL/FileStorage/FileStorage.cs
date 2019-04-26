using System;
using System.IO;
using System.Security.Policy;
using System.Web.Hosting;

namespace MyBase.DAL.FileStorage
{
    public class FileStorage : IFileStorage
    {
        public Url SaveFile(Stream stream, string fileName)
        {
            var directoryName = "/Images/Avatars/";
            var fileExtension = Path.GetExtension(fileName);
            var newFileName = directoryName + Guid.NewGuid().ToString() + fileExtension;

            if (!Directory.Exists(HostingEnvironment.MapPath(directoryName)))
            {
                Directory.CreateDirectory(HostingEnvironment.MapPath(directoryName));
            }

            using (var fileStream = File.Create(HostingEnvironment.MapPath(newFileName)))
            {
                stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(fileStream);
            }

            return new Url(newFileName);
        }
    }
}
