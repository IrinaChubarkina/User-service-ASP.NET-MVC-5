using MyBase.BLL.DataGen;
using MyBase.BLL.DTO;
using MyBase.BLL.Interfaces;
using MyBase.BLL.Services;
using MyBase.WEB.Mappers;
using MyBase.WEB.Models;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBase.WEB.Util
{
    public class UserModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<IMapper<UserViewModel, UserDTO>>().To<UserViewMapper>();
            Bind<IDataGenerator>().To<DataGenerator>();
        }
    }
}