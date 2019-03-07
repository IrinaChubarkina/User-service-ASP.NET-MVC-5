using MyBase.BLL.DTO;
using MyBase.BLL.Interfaces;
using MyBase.BLL.Mappers;
using MyBase.BLL.Services;
using MyBase.DAL.EF;
using MyBase.DAL.Entities;
using MyBase.DAL.Interfaces;
using MyBase.DAL.Repositories;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBase.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        //private string connectionString;
        //public ServiceModule(string connection)
        //{
        //    connectionString = connection;
        //}
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<ApplicationContext>().To<ApplicationContext>().InRequestScope();
            Bind<IMapper<UserDTO, User>>().To<UserMapper>();
            Bind<IMapper<UserDTO, Contact>>().To<ContactMapper>();
            Bind<IMapper<UserDTO, Picture>>().To<PictureMapper>();
            Bind<IUserRepository<User>>().To<UserRepository>();
            Bind<IRepository<Contact>>().To<ContactRepository>();
            Bind<IRepository<Picture>>().To<PictureRepository>();
            Bind<IUserValidator>().To<UserValidator>();
        }
    }
}

