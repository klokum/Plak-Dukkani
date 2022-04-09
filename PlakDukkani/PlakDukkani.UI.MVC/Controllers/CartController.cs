using Microsoft.AspNetCore.Mvc;
using PlakDukkani.UI.MVC.Helpers;
using PlakDukkani.UI.MVC.Models.CartItems;

namespace PlakDukkani.UI.MVC.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()    //Sepet sayfası
        {
            return View();
        }

        public IActionResult AddToCart(int id)
        {
            Cart cart = new Cart();
            CartItem cartItem = new CartItem();
            cart.Add(cartItem);
            HttpContext.Session.Set<Cart>("cart", cart);
        }
    }
}
