using AutoMapper;
using MyBase.BLL.DTO;
using MyBase.WEB.Models;

namespace MyBase.WEB.App_Start
{
    public class AutoMapperProfileWEB : Profile
    {
        public AutoMapperProfileWEB()
        {
            CreateMap<UserDTO, UserViewModel>();
            CreateMap<UserViewModel, UserDTO>();
        }
    }
}