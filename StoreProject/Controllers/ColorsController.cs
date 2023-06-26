using System.Threading.Tasks;
using StoreProject.DAL;
using StoreProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StoreProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ColorsController : Controller
    {
        private readonly BaseEntity<Color> _colorRepo;

        public ColorsController(BaseEntity<Color> colorrepo) => _colorRepo = colorrepo;
        public async Task<IActionResult> Index(int ? pageNumber)
        {
            var data = await  PaginatedList<Color>.CreateAsync(_colorRepo.GetAll(x=>x.IsDelete==false), pageNumber ?? 1, 9);
            return View(data);
        }
        // GET: Measurements/Create
        public IActionResult Create() => PartialView();
        // POST: Measurements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Color color)
        {
            if (ModelState.IsValid)
            {
               await _colorRepo.AddEntityAsync(color);
                return RedirectToAction(nameof(Index));
            }
            return View(color);
        }

        // GET: Measurements/Edit/5
        public async Task<IActionResult> Edit(int id) => PartialView(await _colorRepo.GetByIdAsync(id));

        // POST: Measurements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( Color color)
        {
            if (ModelState.IsValid)
            {
                await _colorRepo.UpdateEntityAsync(color);
                return RedirectToAction(nameof(Index));
            }
            return View(color);
        }
        // POST: Measurements/Delete/5
        [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
           await _colorRepo.DeleteEntityAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
