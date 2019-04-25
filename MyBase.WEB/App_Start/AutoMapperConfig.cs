using AutoMapper;

namespace MyBase.WEB.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<AutoMapperProfile>();
                config.AddProfile<BLL.Infrastructure.AutoMapperProfile>();
            });
        }
    }
}