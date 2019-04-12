using AutoMapper;
using MyBase.BLL.DTO;
using MyBase.DAL.Entities;

namespace MyBase.BLL.Infrastructure
{
    public class AutoMapperProfileBLL : Profile
    {
        public AutoMapperProfileBLL()
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
        }
    }
}
