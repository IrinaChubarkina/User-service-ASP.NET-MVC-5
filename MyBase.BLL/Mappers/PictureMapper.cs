using MyBase.BLL.DTO;
using MyBase.BLL.Interfaces;
using MyBase.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBase.BLL.Mappers
{
    public class PictureMapper : IMapper<UserDTO, Picture>
    {
        public Picture Convert(UserDTO source)
        {
            return new Picture
            {
                Id = source.PictureId,
                Image = source.Image,
                //NAME !!!?
            };
        }

        public UserDTO Convert(Picture source) // не надо
        {
            throw new NotImplementedException();
        }
    }
}
