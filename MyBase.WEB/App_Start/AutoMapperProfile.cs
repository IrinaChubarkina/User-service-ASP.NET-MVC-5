using AutoMapper;
using MyBase.BLL.Dto;
using MyBase.WEB.Models;

namespace MyBase.WEB.App_Start
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDto, UserViewModel>();
            CreateMap<UserViewModel, UserDto>();
        }
    }
}