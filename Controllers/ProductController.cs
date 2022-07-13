using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductGallary.Constants;
using ProductGallary.Models;
using ProductGallary.Reposatories;
using ProductGallary.TDO;

namespace ProductGallary.Controllers
{
    public class ProductController : Controller
    {

        //DIP
        IReposatory<Product> ProductRepo;
        IReposatory<Category> CategRepo;
        private readonly UserManager<ApplicationUser> userManger;
        IWebHostEnvironment webHostEnvironment;
        //DI dependance injection (constructor)
        public ProductController(IReposatory<Product> _productRepo, IWebHostEnvironment webHostEnvironment , IReposatory<Category> _CategRepo , UserManager<ApplicationUser> userManger)
        {
            ProductRepo = _productRepo;
            CategRepo = _CategRepo;
            this.webHostEnvironment = webHostEnvironment;
        }
        //image upload
        //get all products

        public IActionResult Index()
        {
            var xProduct = ProductRepo.GetAll();

            return View(xProduct);
        }

        public IActionResult Details(Guid id)
        {

            var xProduct = ProductRepo.GetById(id);

            return View(xProduct);
        }

        [Authorize(Roles = $"{Roles.BUYER_ROLE}")]
        public IActionResult New()
        {
            ViewData["CategoryList"] = CategRepo.GetAll();
            return View(new ProductCreateTDO());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = $"{Roles.BUYER_ROLE}")]
        public IActionResult Savenew(ProductCreateTDO createTDO)

        {
           ViewData["CategoryList"] = CategRepo.GetAll();


            if (ModelState.IsValid == true)
            {
                Product xproduct = new Product();
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images/ProductImages");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + createTDO.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    createTDO.Image.CopyTo(fileStream);
                    fileStream.Close();
                }
                xproduct.Name=createTDO.Name;
                xproduct.Image= uniqueFileName;
                xproduct.Price=createTDO.Price;
                xproduct.HasDiscount=createTDO.HasDiscount;
                xproduct.DiscountPercentage = createTDO.DiscountPercentage;
                xproduct.Description = createTDO.Description;
                ProductRepo.Insert(xproduct);
                return RedirectToAction("Index");
            }
            else
            {
                return View("New");
            }
        }

        // Edit
        [Authorize(Roles = $"{Roles.BUYER_ROLE}")]

        public IActionResult Update(Guid id)
        {
            ViewData["CategoryList"] = CategRepo.GetAll();
            var oldproduct = ProductRepo.GetById(id);
            return View(oldproduct);
        }
        [Authorize(Roles = $"{Roles.BUYER_ROLE}")]

        public IActionResult Saveupdate(Guid id, Product newproduct)
        {
            ViewData["CategoryList"] = CategRepo.GetAll();

            if (ModelState.IsValid)
            {

                ProductRepo.Update(id, newproduct);
                return RedirectToAction("Index");
            }

            return View("Edit", newproduct);

        }

        //delete

        [Authorize(Roles = $"{Roles.BUYER_ROLE}")]

        public IActionResult Delete(Guid id)
        {
            Product oldproduct =ProductRepo.GetById(id);
            return View(oldproduct);

        }
        [Authorize(Roles = $"{Roles.BUYER_ROLE}")]

        public IActionResult ConfirmDelete(Guid id)
        {
            ProductRepo.Delete(id);
            return RedirectToAction("Index");
        }
        

    }
}
