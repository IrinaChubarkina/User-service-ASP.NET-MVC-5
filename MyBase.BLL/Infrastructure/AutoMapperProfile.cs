using AutoMapper;
using MyBase.BLL.Dto;
using MyBase.DAL.Entities;

namespace MyBase.BLL.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}
