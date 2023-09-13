using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreProject.DAL;
using StoreProject.Models;
using System.Linq;
using System.Threading.Tasks;

namespace StoreProject.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ExpenseRepo _expenseRepo;

        public ExpensesController(ExpenseRepo expenseRepo) => _expenseRepo = expenseRepo;
        public async Task<IActionResult> Index(int? pageNumber)
           => View(await PaginatedList<Expense>.CreateAsync(_expenseRepo.GetAsQueryable(),pageNumber??1,10));
        public IActionResult StoreMoney()
        {
            var totalpaid = _expenseRepo.GetTotalMoneyForStore();
            totalpaid -= _expenseRepo.GetAsQueryable().Sum(x => x.Pay);
            return Ok(totalpaid);
        }
        [HttpGet]
        public IActionResult Create() => PartialView();
        public async Task<IActionResult> Create(Expense entity)
        {
            if (ModelState.IsValid)
            {
                await _expenseRepo.AddEntityAsync(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
                return NotFound();
            var store = await _expenseRepo.GetByIdAsync(id);
            if (store == null)
                return NotFound();
            return PartialView(store);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Expense entity)
        {
            if (ModelState.IsValid)
            {
                await _expenseRepo.UpdateEntityAsync(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _expenseRepo.DeleteEntityAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
