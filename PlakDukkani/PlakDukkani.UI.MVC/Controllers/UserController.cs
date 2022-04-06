using Microsoft.AspNetCore.Mvc;
using PlakDukkani.BLL.Abstract;
using PlakDukkani.BLL.Concrete.ResultServiceBLL;
using PlakDukkani.ViewModel.UserViewModels;
using System;

namespace PlakDukkani.UI.MVC.Controllers
{
    public class UserController : Controller
    {
        IUserBLL userService;
        public UserController(IUserBLL userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {  
            
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserCreateVM user)
        {
            if (ModelState.IsValid)
            {
                ResultService<UserCreateVM> resultService = userService.Insert(user);
                return RedirectToAction(nameof(Index),nameof(UserController));
            }
            return View();
        }

        public IActionResult ActivedUser(Guid guid)
        {
            ResultService<bool> result = userService.ActivedUser(guid);
            return View();
        }
        
        public IActionResult Login()
        {    
            
            return View();
        }
    }
}
