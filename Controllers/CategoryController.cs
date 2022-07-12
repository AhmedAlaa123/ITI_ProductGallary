using Microsoft.AspNetCore.Mvc;
using ProductGallary.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using ProductGallary.Reposatories;
using ProductGallary.TDO;
using Microsoft.AspNetCore.Authorization;
using ProductGallary.Constants;

namespace ProductGallary.Controllers
{
    public class CategoryController : Controller
    {
        IReposatory<Category> CategRepo;
        private readonly UserManager<ApplicationUser> userManger;
        //  CategoryRepository courseRepository;
        public CategoryController(IReposatory<Category> _CategRepo , UserManager<ApplicationUser> f)
        {
            CategRepo = _CategRepo;
            userManger = f;
        }
        public IActionResult Index()
        {

            var Cat = CategRepo.GetAll();

            return View(Cat);
        }
        public IActionResult New()
        {
            return View(new Category());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = $"{Roles.ADMIN_ROLE}")]
        public IActionResult Savenew(Category newCateg)

        {
             var userID= userManger.GetUserId(HttpContext.User);

            if (ModelState.IsValid == true)
            {
                newCateg.User_Id = userID;
                //save
                CategRepo.Insert(newCateg);
                return RedirectToAction("Index");
            }
            else
            {
                return View("New", newCateg);
            }
        }

        public IActionResult Update(Guid id)
        {
            //ViewData["GallaryList"] = ProductRepo.GetAll();
            var oldcateg = CategRepo.GetById(id);
            return View(oldcateg);
        }

        public IActionResult Saveupdate(Guid id, Category newcat)
        {
            ViewData["CategList"] = CategRepo.GetAll();
            if (ModelState.IsValid)
            {
                CategRepo.Update(id, newcat);
                return RedirectToAction("Index");
            }
            return View("Edit", newcat);
        }

        public IActionResult Delete(Guid id)
        {
            CategRepo.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
