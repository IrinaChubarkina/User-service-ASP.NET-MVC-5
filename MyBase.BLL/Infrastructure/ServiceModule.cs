using MyBase.DAL.EF;
using MyBase.DAL.Entities;
using MyBase.DAL.Interfaces;
using MyBase.DAL.Repositories;
using Ninject.Modules;
using Ninject.Web.Common;

namespace MyBase.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<ApplicationContext>().To<ApplicationContext>().InRequestScope();
            Bind<IUserRepository<User>>().To<UserRepository>();
        }
        
    }
}

