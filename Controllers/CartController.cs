using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductGallary.Constants;
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
        IFilter<Cart> filter;
        public CartController(CartInterface cartrepo, UserManager<ApplicationUser> userManger, IReposatory<Product> reposatory, IFilter<Cart> filter)
        {
            this.cartrepo = cartrepo;
            this.userManger = userManger;
            this.reposatory = reposatory;
            this.filter = filter;
        }

        public IActionResult Index()
        {
            UserDto infoDTO = new UserDto();
            var userID = userManger.GetUserId(HttpContext.User);
            infoDTO.user_id = userID;
            return RedirectToAction("shoppingcart",infoDTO);
        }
        [Authorize(Roles = $"{Roles.CUSTOMER_ROLE}")]
        public IActionResult shoppingcart(string user_id)
        {

            var cart = filter.filter(user_id); 
            return View(cart);
        }
        [HttpPost]
       [Authorize(Roles = $"{Roles.CUSTOMER_ROLE}")]
        public IActionResult addtocart(Guid id)
        {
            var userID = userManger.GetUserId(HttpContext.User);
            if (userID!=null)
            {
                //Cart cart = new Cart();
                //var p = reposatory.GetById(id);
                if (ModelState.IsValid)
                {
                    List<Guid> products;
                    if (ViewData[$"{Constant.PRODUCTS}"]==null)
                    {
                        products = new List<Guid>()
                        {
                            id
                        };
                        
                    }
                    else
                    {
                        products =(List<Guid>)ViewData[$"{Constant.PRODUCTS}"];
                        products.Add(id);
                        //ViewData[$"{Constant.PRODUCTS}"] = products;


                    }
                    ViewData[$"{Constant.PRODUCTS}"] = products;
                    //cart.User_Id = userID;
                    //cart.products.Add(p);
                    //Console.WriteLine(cart.products);
                    //cartrepo.Add(cart);
                    return RedirectToAction("index");
                }
                return Redirect("Details");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [Authorize(Roles = $"{Roles.CUSTOMER_ROLE}")]
        public IActionResult delete(Guid id)
        {
            cartrepo.Delete(id);
            return RedirectToAction("shoppingcart");
        }
    }
}
