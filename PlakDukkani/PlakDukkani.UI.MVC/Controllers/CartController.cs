using Microsoft.AspNetCore.Mvc;
using PlakDukkani.UI.MVC.Models.CartItems;

namespace PlakDukkani.UI.MVC.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()    //Sepet sayfası
        {
            return View();
        }

    }
}
