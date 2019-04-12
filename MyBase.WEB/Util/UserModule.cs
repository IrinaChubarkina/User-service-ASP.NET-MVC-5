using AutoMapper;
using MyBase.BLL.DTO;
using MyBase.BLL.Infrastructure;
using MyBase.BLL.Services.UserService;
using MyBase.WEB.App_Start;
using MyBase.WEB.Models;
using Ninject;
using Ninject.Modules;

namespace MyBase.WEB.Util
{
    public class UserModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
        }
}
}