using MyBase.BLL.DTO;
using MyBase.BLL.Interfaces;
using MyBase.DAL.Entities;
using System;

namespace MyBase.BLL.Mappers
{
    public class PictureMapper : IMapper<UserDTO, Picture>
    {
        public Picture Convert(UserDTO source)
        {
            return new Picture {
                Id = source.PictureId,
                Image = source.Image,
                Name = source.PictureName
            };
        }

        public UserDTO Convert(Picture source)
        {
            throw new NotImplementedException();
        }
    }
}
