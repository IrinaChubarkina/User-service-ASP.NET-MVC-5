using MyBase.BLL.DTO;
using MyBase.BLL.Interfaces;
using MyBase.WEB.Models;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using MyBase.BLL.DataGen.Interfaces;

namespace MyBase.WEB.Controllers
{
    public class HomeController : Controller
    {
        IUserService service;
        IFakeUsersCreator fakeUsersCreator;
        IMapper<UserViewModel, UserDTO> mapper;

        public HomeController(IUserService serv, IMapper<UserViewModel, UserDTO> m, IFakeUsersCreator cr)
        {
            service = serv;
            mapper = m;
            fakeUsersCreator = cr;
        }

        public ActionResult Index(int? page, int? size)
        {
            var pageSize = size ?? 10;
            var pageNumber = page ?? 1;
            var pageInfo = new PageInfo
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = service.GetUsersCount()
            };

            var users = new List<UserViewModel>();
            var usersDto = service.GetList(pageSize, pageNumber);
            foreach (var u in usersDto)
            {
                users.Add(mapper.Convert(u));
            }

            var indexViewModel = new IndexViewModel
            {
                PageInfo = pageInfo,
                Users = users
            };

            return View(indexViewModel);
        }

        public ActionResult Details(int id)
        {
            var userDto = service.GetUser(id);
            var user = mapper.Convert(userDto);
            return View(user);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel user, HttpPostedFileBase uploadImage)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            if (uploadImage != null)
            {
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    user.Image = binaryReader.ReadBytes(uploadImage.ContentLength);
                }
            }

            var userDto = mapper.Convert(user);
            service.Create(userDto);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var userDto = service.GetUser(id);
            var user = mapper.Convert(userDto);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel user, HttpPostedFileBase uploadImage)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            if (uploadImage != null)
            {
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    user.Image = binaryReader.ReadBytes(uploadImage.ContentLength);
                }
            }

            var userDto = mapper.Convert(user);
            service.Edit(userDto);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var userDto = service.GetUser(id);
            var user = mapper.Convert(userDto);
            return View(user);
        }

        [HttpPost]
        public ActionResult Delete(UserViewModel user)
        {
            service.Delete(user.Id);
            return View("Deleted", user);
        }

        public ActionResult CreateFakeUsers()
        {
            fakeUsersCreator.CreateFakeUsers();
            return RedirectToAction("Index");
        }
    }
}