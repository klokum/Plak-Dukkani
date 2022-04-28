using Microsoft.AspNetCore.Mvc;
using PlakDukkani.BLL.Abstract;
using PlakDukkani.BLL.Concrete.ResultServiceBLL;
using PlakDukkani.UI.MVC.Helpers;
using PlakDukkani.ViewModel.CartViewModels;

namespace PlakDukkani.UI.MVC.Controllers
{
    public class CartController : Controller
    {
        IAlbumBLL albumService;
        public CartController(IAlbumBLL albumService)
        {
            this.albumService = albumService;   
        }
        public IActionResult Index()    //Sepet sayfası
        {
            return View();
        }

        public IActionResult AddToCart(int id)
        {
            Cart cart = HttpContext.Session.Get<Cart>("cart");
            if (cart == null)
            {
                cart = new Cart();
            }
            
            ResultService<CartItem> result = albumService.GetCartById(id);
            if (!result.HasError)
            {
                CartItem item = result.Data;
                item.Quantity = 1;
                cart.Add(item);
                HttpContext.Session.Set<Cart>("cart", cart);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
