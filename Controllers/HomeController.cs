using Microsoft.AspNetCore.Mvc;
using ProductGallary.Models;
using System.Diagnostics;
using ProductGallary.TDO;
using Microsoft.AspNetCore.Identity;

namespace ProductGallary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IReposatory<Gallary> reposatory;
        private readonly UserManager<ApplicationUser> userManger;
        public HomeController(ILogger<HomeController> logger, IReposatory<Gallary> reposatory, UserManager<ApplicationUser> userManger)
        {
            _logger = logger;
            this.reposatory = reposatory;
            this.userManger = userManger;
        }

        public IActionResult Index()
        {

            GalaryInfoDTO galary = new GalaryInfoDTO();
            var userID = userManger.GetUserId(HttpContext.User);
            galary.user_id = userID;

            return View(galary);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}