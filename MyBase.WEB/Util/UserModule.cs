using MyBase.BLL.DTO;
using MyBase.BLL.Services.UserService;
using MyBase.BLL.Services.UserService.Mappers;
using MyBase.WEB.Mappers;
using MyBase.WEB.Models;
using Ninject.Modules;

namespace MyBase.WEB.Util
{
    public class UserModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<IUserMapper<UserDTO, UserViewModel>>().To<UserViewMapper>();
        }
    }
}