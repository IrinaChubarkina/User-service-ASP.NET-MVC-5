using MyBase.BLL.Dto;
using MyBase.BLL.Infrastructure;
using MyBase.BLL.Services.UserService;
using MyBase.WEB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyBase.WEB.Controllers
{
    public class UserController : Controller
    {
        readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ActionResult> Index(int? page, int? size)
        {
            var pageSize = size ?? 10;
            var pageNumber = page ?? 1;
            var pageInfo = new PageInfo
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = await _userService.GetUsersCountAsync()
            };

            var usersDto = await _userService.GetUsersAsync(pageSize, pageNumber);
            var users = usersDto.Map<List<UserViewModel>>();

            var indexViewModel = new IndexViewModel
            {
                PageInfo = pageInfo,
                Users = users
            };

            return View(indexViewModel);
        }

        public async Task<ActionResult> Details(int id)
        {
            var userDto = await _userService.GetUserByIdAsync(id);
            var user = userDto.Map<UserViewModel>();

            return View(user);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            if (user.File != null)
            {
                var pathToImage = SaveFileAndGetPath(user.File);
                user.Image = pathToImage;
            }

            var userDto = user.Map<UserDto>();
            var newUserId = await _userService.CreateUserAsync(userDto);

            TempData["Message"] = "Пользователь создан";

            return RedirectToAction("Details", new { id = newUserId });
        }

        public async Task<ActionResult> Edit(int id)
        {
            var userDto = await _userService.GetUserByIdAsync(id);
            var user = userDto.Map<UserViewModel>();

            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            if (user.File != null)
            {
                var pathToImage = SaveFileAndGetPath(user.File);
                user.Image = pathToImage;
            }

            var userDto = user.Map<UserDto>();
            await _userService.UpdateUserAsync(userDto);

            TempData["Message"] = "Изменения сохранены";

            return RedirectToAction("Details", new { id = user.Id });
        }

        public async Task<ActionResult> Delete(int id)
        {
            var userDto = await _userService.GetUserByIdAsync(id);
            var user = userDto.Map<UserViewModel>();

            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(UserViewModel user)
        {
            await _userService.DeleteUserByIdAsync(user.Id);
            return View("Deleted", user);
        }

        public async Task<ActionResult> FillStorageWithUsers()
        {
            await _userService.FillStorageWithFakeUsersAsync();
            TempData["Message"] = "Пользователи созданы";

            return RedirectToAction("Index");
        }

        private string SaveFileAndGetPath(HttpPostedFileBase file)
        {
            var directoryName = "/Images/Avatars/";
            var fileExtension = Path.GetExtension(file.FileName);
            var newFileName = directoryName + Guid.NewGuid().ToString() + fileExtension;

            if (!Directory.Exists(Server.MapPath(directoryName)))
            {
                Directory.CreateDirectory(Server.MapPath(directoryName));
            }
            file.SaveAs(Server.MapPath(newFileName));

            return newFileName;
        }
    }
}