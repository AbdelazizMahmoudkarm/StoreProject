using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreProject.DAL;
using StoreProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace StoreProject.Controllers
{
    [Authorize(Roles ="Admin")]
    public class StoresController : Controller
    {
        private readonly BaseEntity<Store> _storeRepo;
        public StoresController(BaseEntity<Store> storeRepo)
        {
            this._storeRepo = storeRepo;
        }
        // GET: Stores
        public async Task<IActionResult> Index(int? index)
        {
            var model = _storeRepo.GetAsQueryable(x=>x.IsDelete==false);
            return View(await PaginatedList<Store>.CreateAsync(model,index??1,9));
        }

        // GET: Stores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var store = await _storeRepo.GetAsQueryable()
                .FirstOrDefaultAsync(m => m.StoreId == id);
            if (store == null)
            {
                return NotFound();
            }

            return View(store);
        }

        // GET: Stores/Create
        public IActionResult Create()
        {
            return PartialView();
        }

        // POST: Stores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StoreId,StoreName")] Store store)
        {
            if (ModelState.IsValid)
            {
                await _storeRepo.AddEntityAsync(store);
                return RedirectToAction(nameof(Index));
            }
            return View(store);
        }

        // GET: Stores/Edit/5
        public async Task<IActionResult> Edit(int  id)
        {
            if (id == 0)
                return NotFound();
            

            var store = await _storeRepo.GetByIdAsync(id);
            if (store == null)
                return NotFound();
            return PartialView(store);
        }

        // POST: Stores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( [Bind("StoreId,StoreName")] Store store)
        {

            if (ModelState.IsValid)
            {
                    await _storeRepo.UpdateEntityAsync(store);
                return RedirectToAction(nameof(Index));
            }
            return View(store);
        }

        // GET: Stores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
           
            var store = await _storeRepo.GetAsQueryable().FirstOrDefaultAsync(m => m.StoreId == id);
            if (store == null)
            {
                return NotFound();
            }

            return View(store);
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
       // [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _storeRepo.DeleteEntityAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
