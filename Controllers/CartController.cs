using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductGallary.Models;
using ProductGallary.Reposatories;
using ProductGallary.TDO;

namespace ProductGallary.Controllers
{
    public class CartController : Controller
    {
        private readonly UserManager<ApplicationUser> userManger;

        CartInterface cartrepo;

        public CartController(CartInterface cartrepo, UserManager<ApplicationUser> userManger)
        {
            this.cartrepo = cartrepo;
            this.userManger = userManger;
            
        }

        public IActionResult shoppingcart()
        {
            return View();
        }
        public IActionResult addtocart(Carttdo carttdo)
        {
            if (ModelState.IsValid)
            {
            Cart cart = new Cart();

            var userID = userManger.GetUserId(HttpContext.User);
            cart.User_Id = userID;
            cart.Order_Id = carttdo.Order_Id;
            
            cartrepo.Add(cart);
            return View("shoppingcart");
            }
            return Redirect("Details");
        }
    }
}
