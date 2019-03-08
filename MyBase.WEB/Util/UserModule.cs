using MyBase.BLL.DataGen.Interfaces;
using MyBase.BLL.DataGen.Services;
using MyBase.BLL.DTO;
using MyBase.BLL.Interfaces;
using MyBase.BLL.Services;
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
            Bind<IMapper<UserViewModel, UserDTO>>().To<UserViewMapper>();
            Bind<IFakeUsersCreator>().To<FakeUsersCreator>();
        }
    }
}