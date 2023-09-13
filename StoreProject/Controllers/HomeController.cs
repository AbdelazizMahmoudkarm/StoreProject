using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreProject.DAL.ReposatoryClasess;
using StoreProject.Models;

namespace StoreProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly BrandRepo _brandRepo;
        public HomeController(BrandRepo brandRepo) => _brandRepo = brandRepo;

        [HttpPost][Produces("application/json")]
        public IActionResult Brand()
        {
            var brand = _brandRepo.GetAsQueryable().Select(x=>x.BrandName).FirstOrDefault();
            if (brand != null)
                return Ok(brand);
            else
                return Ok();
        }
        [HttpGet]
        public IActionResult Create()=> PartialView();
        [HttpPost]
        public async Task<IActionResult> Create(Brand brand)
        {
           await _brandRepo.AddEntityAsync(brand);
            return Ok();
        }
        public IActionResult Index()
        {
            ViewBag.Brand = _brandRepo.GetAsQueryable();
            return View();
        }
        [Produces("application/json")]
        public async Task<IActionResult> RemoveBrand()
        {
            var brand = _brandRepo.GetAsQueryable().Select(x => x.BrandId).FirstOrDefault();
            if (brand is not 0)  
                return Ok(await _brandRepo.DeleteEntityAsync(brand));
            else
                return Ok();
        }
    }
}
