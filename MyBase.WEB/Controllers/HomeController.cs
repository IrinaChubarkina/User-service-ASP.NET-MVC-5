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
                
        // GET: Default
        public ActionResult Index()
        {
            List<UserViewModel> users = new List<UserViewModel>();
            var usersDto = service.GetList();
            foreach (var u in usersDto)
            {
                users.Add(mapper.ConvertToUpLayer(u));
            }
            return View(users);
        }

        // GET: Default/Details/5
        public ActionResult Details(int id)
        {
            var userDto = service.Get(id);
            var user = mapper.ConvertToUpLayer(userDto);
            return View(user);
        }

        // GET: Default/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Default/Create
        [HttpPost]
        public ActionResult Create(UserViewModel user)
        {
            try
            {
                var userDto = mapper.ConvertToDownLayer(user);
                service.Add(userDto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default/Edit/5
        public ActionResult Edit(int id)
        {
            var userDto = service.Get(id);
            var user = mapper.ConvertToUpLayer(userDto);
            return View(user);
        }

        // POST: Default/Edit/5
        [HttpPost]
        public ActionResult Edit(UserViewModel user)
        {            
            try
            {
                var userDto = mapper.ConvertToDownLayer(user);
                service.Edit(userDto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            service.Delete(id);
            return RedirectToAction("Index");
        }






         //public ActionResult Index()
         //{
         //    List<UserViewModel> users = new List<UserViewModel>();
         //    var usersDto = service.GetList();
         //    foreach (var u in usersDto)
         //    {
         //        users.Add(mapper.ConvertToUpLayer(u));
         //    }
         //    //ViewBag.Users = users;
         //    return View("View", users);
         //    //return View(users);
         //}

         //public ActionResult Add()
         //{
         //    return View();
         //}

         //[HttpPost]
         //public ActionResult Add(UserViewModel user) // user + contact + image
         //{
         //    // userRequest -> mapping -> userDto 
         //    var userDto = mapper.ConvertToDownLayer(user);
         //    service.Add(userDto);
         //    return Redirect("Index");
         //}

         //public ActionResult Delete()
         //{
         //    return View();
         //}

    }
}