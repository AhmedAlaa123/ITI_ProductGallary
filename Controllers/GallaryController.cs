using Microsoft.AspNetCore.Mvc;
using ProductGallary.Models;
using ProductGallary.TDO;

namespace ProductGallary.Controllers
{
    public class GallaryController : Controller
    {
        IWebHostEnvironment env;
        IReposatory<Gallary> reposatory;
        public GallaryController(IReposatory<Gallary> reposatory, IWebHostEnvironment env)
        {
            this.reposatory = reposatory;
            this.env = env;
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

            if (ModelState.IsValid)
            {

                Gallary gallary = new Gallary();

                //upload fole to server

                string uploadimg = Path.Combine(env.WebRootPath, "img/GallaryLogo");
                string uniqe = Guid.NewGuid().ToString() + "_" +galaryCreate.Logo.FileName;
                string pathfile = Path.Combine(uploadimg, uniqe);
                using (var filestream = new FileStream(pathfile, FileMode.Create))
                {
                    galaryCreate.Logo.CopyTo(filestream);
                    filestream.Close();
                }

                gallary.Name = galaryCreate.name;
                gallary.Logo = uniqe;
                gallary.Created_Date = DateTime.Now;
                reposatory.Insert(gallary);
                return Redirect("index");
            }
            return View("inseart");

        }
        public IActionResult edit(Guid id)
        {
            var gallary = reposatory.GetById(id);
            return View(gallary);
        }
        [HttpPost]
        public IActionResult update(Guid id,Gallary gallary)
        {
            if (ModelState.IsValid)
            {
                reposatory.Update(id,gallary);
                return RedirectToAction("index");
            }
            else
            {
            return View("edit");
            }

        }
        public IActionResult delete(Guid id)
        {
            Gallary gallary = reposatory.GetById(id);
            return View(gallary);
        }
        public IActionResult confirmdelete(Guid id)
        {
            reposatory.Delete(id);
            return RedirectToAction("index");
        }










    }
}
