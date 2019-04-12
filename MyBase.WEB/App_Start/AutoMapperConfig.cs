using AutoMapper;
using MyBase.BLL.DTO;
using MyBase.WEB.Models;

namespace MyBase.WEB.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<UserDTO, UserViewModel>();
                cfg.CreateMap<UserViewModel, UserDTO>();
            });
        }
    }
}