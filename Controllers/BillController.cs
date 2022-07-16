using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductGallary.Constants;
using ProductGallary.Models;
using ProductGallary.Reposatories;
using ProductGallary.TDO;

namespace ProductGallary.Controllers
{
    public class BillController:Controller
    {
        private readonly IReposatory<Order> ordersReposatory;
        private readonly IReposatory<Bill> billsReposatory;
        private readonly UserManager<ApplicationUser> userManger;
        private readonly CartInterface cartReposatory;

        public BillController(IReposatory<Order> _ordersReposatory, IReposatory<Bill> _billsReposatory, UserManager<ApplicationUser> _userManger, CartInterface _cartReposatory)
        {
            this.ordersReposatory=_ordersReposatory;
            this.billsReposatory = _billsReposatory;
            this.userManger = _userManger;
            cartReposatory = _cartReposatory;
        }

        [Authorize(Roles =$"{Roles.CUSTOMER_ROLE}")]
        [HttpGet]
        // this action used to Display Bill
        public async Task<IActionResult> DisplayBill()
        {
            if(TempData.ContainsKey(Constant.ORDERID))
            {
                Guid billId = (Guid)TempData[Constant.ORDERID];
                Order order = this.ordersReposatory.GetById(billId);
                ApplicationUser user = await userManger.GetUserAsync(this.HttpContext.User);
                BillInfoDTO billInfoDTO = new BillInfoDTO
                {
                    Id = billId,
                    currentDate = DateTime.Now.Date.ToString(),
                    currentTime = DateTime.Now.TimeOfDay.ToString(),
                    userName = user.Name,
                    products = new List<ProductInfoDTO>()
                    
                };
                Cart cart = cartReposatory.GetById(order.Cart_Id);
                foreach (Product pro in order.Cart.products)
                {
                    ProductInfoDTO productInfo = new ProductInfoDTO
                    {
                        Id=pro.Id,
                        Name=pro.Name,
                        Image=pro.Image, 
                        Price= pro.Price
                    };
                    billInfoDTO.Price += (float)(pro.Price==null?0:pro.Price);
                    billInfoDTO.products.Add(productInfo);
                }
                this.billsReposatory.Insert(new Bill { OrderId = billId });
                return View("DisplayBill", billInfoDTO);

            }
            return RedirectToAction("Index","Home");
        }


    }
}
