﻿using MyBase.BLL.DTO;
using MyBase.BLL.Interfaces;
using MyBase.WEB.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
                users.Add(mapper.Convert(u));
            }
            return View(users);
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
                service.Add(userDto);

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
            //service.Delete(id);
            //return RedirectToAction("Index");
            //return View();
            var userDto = service.Get(id);
            var user = mapper.Convert(userDto);
            return View(user);
        }
        [HttpPost]
        public ActionResult Delete(UserViewModel user)
        {
            service.Delete(user.Id);
            //return RedirectToAction("Index");
            return View("Deleted", user);
        }
    }
}