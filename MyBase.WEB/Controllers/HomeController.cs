using MyBase.BLL.DTO;
using MyBase.BLL.Interfaces;
using MyBase.WEB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using MyBase.BLL.DataGen;

namespace MyBase.WEB.Controllers
{
    public class HomeController : Controller
    {
        IUserService service;
        IDataGenerator dataGenerator;
        IMapper<UserViewModel, UserDTO> mapper;

        public HomeController(IUserService serv, IMapper<UserViewModel, UserDTO> m, IDataGenerator dg)
        {
            service = serv;
            mapper = m;
            dataGenerator = dg;
        }

        // GET: Default
        public ActionResult Index(int? page, int? size)
        {
            List<UserViewModel> users = new List<UserViewModel>();
            int pageSize = size ?? 10;
            int pageNumber = page ?? 1;
            PageInfo pageInfo = new PageInfo
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = service.Count()
            };
            var usersDto = service.GetList(pageSize, pageNumber);
            foreach (var u in usersDto)
            {
                users.Add(mapper.Convert(u));
            }
            IndexViewModel ivm = new IndexViewModel
            {
                PageInfo = pageInfo,
                Users = users
            };
            return View(ivm);
        }

        // GET: Default/Details/5
        public ActionResult Details(int id)
        {
            var userDto = service.Get(id);
            var user = mapper.Convert(userDto);
            return View(user);
        }

        // GET: Default/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Default/Create
        [HttpPost]
        public ActionResult Create(UserViewModel user, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                if (uploadImage != null)
                {
                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }
                    user.Image = imageData;
                }
                var userDto = mapper.Convert(user);
                service.Create(userDto);

                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Default/Edit/5
        public ActionResult Edit(int id)
        {
            var userDto = service.Get(id);
            var user = mapper.Convert(userDto);
            return View(user);
        }

        // POST: Default/Edit/5
        [HttpPost]
        public ActionResult Edit(UserViewModel user, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                if (uploadImage != null)
                {
                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }
                    user.Image = imageData;
                }
                var userDto = mapper.Convert(user);
                service.Edit(userDto);
                return RedirectToAction("Index");
            }
            return View(user);            
        }

        public ActionResult Delete(int id)
        {
            var userDto = service.Get(id);
            var user = mapper.Convert(userDto);
            return View(user);
        }
        [HttpPost]
        public ActionResult Delete(UserViewModel user)
        {
            service.Delete(user.Id);
            return View("Deleted", user);
        }

        public ActionResult CreateFakeData()
        {
            //string connectionString =  ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            int number = 100;
            dataGenerator.GenerateData(number);
            return RedirectToAction("Index");
        }
    }
}