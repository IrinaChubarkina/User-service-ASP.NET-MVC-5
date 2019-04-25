using MyBase.BLL.Services.UserService;
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