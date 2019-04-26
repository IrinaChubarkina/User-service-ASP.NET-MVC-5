using MyBase.DAL.EF;
using MyBase.DAL.FileStorage;
using MyBase.DAL.Repositories;
using MyBase.DAL.Repositories.Interfaces;
using MyBase.DAL.UnitOfWork;
using Ninject.Modules;
using Ninject.Web.Common;

namespace MyBase.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<ApplicationContext>().To<ApplicationContext>()
                .InRequestScope()
                .WithConstructorArgument("connectionString", ConfigurationManager.ConnectionString());
            Bind<IUserRepository>().To<UserRepository>();
            Bind<IFileStorage>().To<FileStorage>();
        }
    }
}

