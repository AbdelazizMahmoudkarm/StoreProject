using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreProject.DAL;
using StoreProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace StoreProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MeasurementsController : Controller
    {

        private readonly MeasureRepo _measurerepo;

        public MeasurementsController(MeasureRepo measurrepo) => _measurerepo = measurrepo;

        // GET: Measurements
        public async Task<IActionResult> Index(int? pageNumber)
        {
            var data = await PaginatedList<Measure>.CreateAsync(_measurerepo.GetAll(x=>x.IsDelete==false),pageNumber?? 1,9);
            return View(data);
        }

        // GET: Measurements/Details/5

        // GET: Measurements/Create
        public IActionResult Create()
        {
            return PartialView();
        }

        // POST: Measurements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Measure measure)
        {
                await _measurerepo.AddEntityAsync(measure);
                return RedirectToAction(nameof(Index));
        }

        // GET: Measurements/Edit/5
        public async Task<IActionResult> Edit(int  id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var measure = await _measurerepo.GetByIdAsync(id);
            if (measure == null)
            {
                return NotFound();
            }
            return PartialView(measure);
        }

        // POST: Measurements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("MeasureId,MeasureName")] Measure measure)
        {

            if (ModelState.IsValid)
            {
                try
                {
                   await _measurerepo.UpdateEntityAsync(measure);
               
                }
                catch (DbUpdateConcurrencyException)
                {
                        throw;   
                }
                return RedirectToAction(nameof(Index));
            }
            return View(measure);
        }

        // POST: Measurements/Delete/5
        [HttpPost, ActionName("Delete")]
       // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _measurerepo.DeleteEntityAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
