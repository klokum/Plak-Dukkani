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
            Cart cart = new Cart(); 
            CartItem cartItem = new CartItem();
            cart.Add(cartItem);
            ResultService<CartItem> result = albumService.GetCartById(id);
            HttpContext.Session.Set<Cart>("cart", cart);
            return RedirectToAction("Index", "Home");
        }
    }
}
