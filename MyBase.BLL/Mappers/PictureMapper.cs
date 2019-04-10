using MyBase.BLL.DTO;
using MyBase.DAL.Entities;

namespace MyBase.BLL.Mappers
{
    public class PictureMapper : IMapper<UserDTO, Picture>
    {
        public Picture Map(UserDTO source)
        {
            return new Picture {                
                Id = source.PictureId ?? 0,
                Image = source.Image,
            };
        }        
    }
}
