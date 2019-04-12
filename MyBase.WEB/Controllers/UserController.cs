using AutoMapper;
using MyBase.BLL.DTO;
using MyBase.BLL.Services.UserService;
using MyBase.BLL.Services.UserService.Mappers;
using MyBase.WEB.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyBase.WEB.Controllers
{
    public class UserController : Controller
    {
        IUserService _userService;

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
                TotalItems = await _userService.GetCountOfUsersAsync()
            };

            var usersDto = await _userService.GetListOfUsersAsync(pageSize, pageNumber);
            var users = Mapper.Map<List<UserViewModel>>(usersDto);

            var indexViewModel = new IndexViewModel
            {
                PageInfo = pageInfo,
                Users = users
            };

            return View(indexViewModel);
        }

        public async Task<ActionResult> Details(int id)
        {
            var userDto = await _userService.GetUserAsync(id);
            var user = Mapper.Map<UserViewModel>(userDto);

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
                using (var binaryReader = new BinaryReader(user.File.InputStream))
                {
                    user.Image = binaryReader.ReadBytes(user.File.ContentLength);
                }

            var userDto = Mapper.Map<UserDTO>(user);
            await _userService.CreateUserAsync(userDto);
            //tempdata успешное создание пользователя (уведомление)
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int id)
        {
            var userDto = await _userService.GetUserAsync(id);
            var user = Mapper.Map<UserViewModel>(userDto);

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
                using (var binaryReader = new BinaryReader(user.File.InputStream))
                {
                    user.Image = binaryReader.ReadBytes(user.File.ContentLength);
                }

            var userDto = Mapper.Map<UserDTO>(user);
            await _userService.UpdateUserAsync(userDto);

            return RedirectToAction("Index");
        }

        //отдать partial view попап
        public async Task<ActionResult> Delete(int id)
        {
            var userDto = await _userService.GetUserAsync(id);
            var user = Mapper.Map<UserViewModel>(userDto);

            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(UserViewModel user)
        {
            await _userService.DeleteUserAsync(user.Id);
            return View("Deleted", user);
        }

        //tempdata - уведомление об успешном выполнении операции
        public async Task<ActionResult> FillStorageWithUsers()
        {
            await _userService.FillStorageWithUsersAsync();
            return RedirectToAction("Index");
        }
    }
}