using Microsoft.AspNetCore.Mvc;
using ProductGallary.Models;
using ProductGallary.TDO;

namespace ProductGallary.Controllers
{
    public class GallaryController : Controller
    {
        IReposatory<Gallary> reposatory;
        public GallaryController(IReposatory<Gallary> reposatory)
        {
            this.reposatory = reposatory;
        }

        public IActionResult Index()
        {
            var gallary = reposatory.GetAll();

            List<GalaryInfoDTO> galaryInfos = new List<GalaryInfoDTO>();
            foreach (var item in gallary)
            {
                GalaryInfoDTO dto = new GalaryInfoDTO();
                dto.Id = item.Id;
                dto.Name = item.Name;
                dto.Logo = item.Logo;
                dto.Created_Date = item.Created_Date;
                galaryInfos.Add(dto);
            }
            return View(galaryInfos);
        }
        public IActionResult Details(Guid id)
        {
            Gallary gal = reposatory.GetById(id);
            return View(gal);
        }
        public IActionResult inseart()
        {

            return View();
        }
        [HttpPost]
        public IActionResult savegallary(GalaryCreateDTO galaryCreate)
        {

            Gallary gallary = new Gallary();
            gallary.Name = galaryCreate.name;
            gallary.Logo = galaryCreate.Logo;
            gallary.Created_Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                reposatory.Insert(gallary);
                return Redirect("Index");
            }
            return View("inseart");

        }

    }
}
