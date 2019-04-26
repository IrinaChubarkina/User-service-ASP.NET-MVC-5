using AutoMapper;
using MyBase.BLL.Services.UserService.Dto;
using MyBase.WEB.Models;

namespace MyBase.WEB.App_Start
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDto, UserViewModel>();
            CreateMap<UserViewModel, UserDto>()
                .ForMember(dest => dest.Stream,
                           opt => opt.MapFrom(source => source.File != null ? source.File.InputStream : null))
                .ForMember(dest => dest.FileName,
                           opt => opt.MapFrom(source => source.File != null ? source.File.FileName : null));
        }
    }
}