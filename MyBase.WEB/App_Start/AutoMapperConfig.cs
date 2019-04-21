using AutoMapper;

namespace MyBase.WEB.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.AddProfile<AutoMapperProfile>();
                cfg.AddProfile<BLL.Infrastructure.AutoMapperProfile>();
            });
        }
    }
}