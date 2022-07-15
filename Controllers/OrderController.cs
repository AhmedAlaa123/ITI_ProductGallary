using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductGallary.Constants;
using ProductGallary.Models;
using ProductGallary.Reposatories;
using ProductGallary.TDO;

namespace ProductGallary.Controllers
{

    public class OrderController : Controller
    {
        private readonly IReposatory<Order> orderReposatory;
        private readonly UserManager<ApplicationUser> userManger;
        private readonly RoleManager<IdentityRole> roleManager;

        public OrderController(UserManager<ApplicationUser> _userManger, RoleManager<IdentityRole> _roleManager)
        {
            orderReposatory = new OrderReposatory();
            userManger = _userManger;
            roleManager = _roleManager;
        }

        private List<OrderInfoDTO> getOrders(List<Order> orders)
        {
                List<OrderInfoDTO> orderInfoDTOs = new List<OrderInfoDTO>();
                foreach (Order order in orders)
                {
                    OrderInfoDTO orderInfoDTO = new OrderInfoDTO
                    {
                        Id = order.Id,
                        DeliveryDate = order.DeliveryDate,
                        OrderDate = order.OrderDate,
                        IsCanceled = order.IsCanceled,
                    };

                    // List Of Products Info
                    List<ProductInfoDTO> productInfoDTOs = new List<ProductInfoDTO>();
                    foreach (Product product in order.OrderProductList.Products)
                    {
                        ProductInfoDTO productInfo = new ProductInfoDTO
                        {
                            Name = product.Name,
                            Image = product.Image,
                            Price = (bool)product.HasDiscount ? (product.DiscountPercentage / 100) * product.Price : product.Price
                        };
                        productInfoDTOs.Add(productInfo);
                    }
                    // add products to orders
                    orderInfoDTO.Products = productInfoDTOs;

                    orderInfoDTOs.Add(orderInfoDTO);

                }
            return orderInfoDTOs;
        }

        [Authorize(Roles =$"{Roles.BUYER_ROLE},{Roles.ADMIN_ROLE}")]
        public async Task<IActionResult> Index()
        {
                
           // var userId = userManger.GetUserId(HttpContext.User);
           //ApplicationUser user=await userManger.FindByIdAsync(userId);

           // if(await userManger.IsInRoleAsync(user,Roles.ADMIN_ROLE))
           // {
           //     // print all Orders To Admin
           //    // List<Order> orders = this.orderReposatory.GetAll();
           //     //List<OrderInfoDTO> orderInfoDTOs = getOrders(orders);
           //     return View(orderInfoDTOs);
                
           // }
           // else if (await userManger.IsInRoleAsync(user, Roles.BUYER_ROLE))
           // {
           //     List<Order> orders=this.orderReposatory.GetAll().Where(order=>order.Cart.User_Id==user.Id).ToList();
           //     List<OrderInfoDTO> orderInfoDTOs = getOrders(orders);
           //     return View(orderInfoDTOs);
           // }
            



            return Content("Wellcome in Orders");
        }
    }
}
