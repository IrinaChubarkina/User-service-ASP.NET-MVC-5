using AutoMapper;
using MyBase.BLL.Infrastructure;

namespace MyBase.WEB.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.AddProfile<AutoMapperProfileWEB>();
                cfg.AddProfile<AutoMapperProfileBLL>();
            });
        }
    }
}