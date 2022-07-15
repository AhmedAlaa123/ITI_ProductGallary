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
        IReposatory<Product> reposatory;

        public CartController(CartInterface cartrepo, UserManager<ApplicationUser> userManger, IReposatory<Product> reposatory)
        {
            this.cartrepo = cartrepo;
            this.userManger = userManger;
            this.reposatory = reposatory;
        }

        public IActionResult shoppingcart()
        {
            var cart = cartrepo.GetAll(); 
            return View(cart);
        }
        [HttpPost]
        public IActionResult addtocart(Guid id)
        {
            var p = reposatory.GetById(id);
            if (ModelState.IsValid)
            {
            Cart cart = new Cart();
            var userID = userManger.GetUserId(HttpContext.User);
            cart.User_Id = userID;
            cart.products.Add(p);
            //Console.WriteLine(cart.products);
            cartrepo.Add(cart);
            return RedirectToAction("shoppingcart");
            }
            return Redirect("Details");
        }
        public IActionResult delete(Guid id)
        {
            cartrepo.Delete(id);
            return RedirectToAction("shoppingcart");
        }
    }
}
