using MyBase.BLL.DTO;
using MyBase.BLL.Interfaces;
using MyBase.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBase.WEB.Controllers
{
    public class HomeController : Controller
    {
        IUserService service;
        IMapper<UserViewModel, UserDTO> mapper;

        public HomeController(IUserService serv, IMapper<UserViewModel, UserDTO> m)
        {
            service = serv;
            mapper = m;
        }
        public ActionResult Index()
        {
            List<UserViewModel> users = new List<UserViewModel>();
            var usersDto = service.GetList();
            foreach (var u in usersDto)
            {
                users.Add(mapper.ConvertToUpLayer(u));
            }
            //ViewBag.Users = users;
            return View(users);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UserViewModel user) // user + contact + image
        {
            // userRequest -> mapping -> userDto 
            var userDto = mapper.ConvertToDownLayer(user);
            service.Add(userDto);
            return Redirect("Index");
        }

    }
}