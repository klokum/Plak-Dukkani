using Microsoft.AspNetCore.Mvc;
using PlakDukkani.BLL.Abstract;
using PlakDukkani.BLL.Concrete;
using PlakDukkani.BLL.Concrete.ResultServiceBLL;
using PlakDukkani.ViewModel.AlbumViewModels;
using System.Collections.Generic;

namespace PlakDukkani.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        //AlbumService albumService  = new AlbumService(); //-> Bu şekilde new'leme yapmayacağız > AddScoped (Constructor Dependency Injection) / .NET Core Provide new'lemesi

        IAlbumBLL albumService;

        public HomeController(IAlbumBLL albumService)
        {
            this.albumService = albumService;
        }

        public IActionResult Index()
        {
            ResultService<List<SingleAlbumVM>> albumResult = albumService.GetSingleAlbums();

            if (!albumResult.HasError)
            {
                return View(albumResult.Data);         
            }
            else
            {
                ViewBag.Message = albumResult.Errors[0].ErrorMessage;
                return View();
            }

        }

        public IActionResult AlbumStore()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

    }
}
