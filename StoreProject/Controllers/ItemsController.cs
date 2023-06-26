using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreProject.DAL;
using StoreProject.Models;
using Microsoft.AspNetCore.Authorization;
using StoreProject.DAL.ReposatoryClasess;

namespace StoreProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ItemsController : Controller
    {
        private readonly CategoryRepo _categoryRepo;
        public ItemsController(CategoryRepo itemRepo) => _categoryRepo = itemRepo;
        [Produces("application/json")]
        public IActionResult SearchItem(String search)
        {
            var items = _categoryRepo.GetAsQueryable(x => x.CategoryName.Contains(search)&&x.IsDelete==false).Include(x=>x.Store).ToList();
            return Ok(items);
        }
        // GET: Items
        public async Task<IActionResult> Index(int? pageNumber)
        {
            var items = _categoryRepo.GetAsQueryable(x=>x.IsDelete==false).Include(x=>x.Store);
            var data =  await PaginatedList<Category>.CreateAsync(items, pageNumber ?? 1, 9);
            return View(data);
        }
        [Produces("application/json")]
        public IActionResult Items(int categoryId)
        {
            var items = _categoryRepo.GetListOfItems(x => x.IsDelete == false && x.CategoryId == categoryId,r=>r.IsDelete==false);
            return PartialView(items);
        }
        public async  Task<IActionResult> DelItemDtails(int id)
        {
           await  _categoryRepo.ItemRepo.DeleteEntityAsync(id);
           return Ok();
        }
        // GET: Items/Create
        [HttpGet]
        public IActionResult Create()
        {
             ViewBag.stores = _categoryRepo.StoreRepo.GetAsQueryable(x=>!x.IsDelete).ToList();
            return PartialView();
        }
        [HttpGet]
        public IActionResult AddItems() => Create();

        [Produces("application/json")]
        public IActionResult GetMesure()
        {
            var measure =  _categoryRepo.ItemRepo.MeasureRepo.GetAsQueryable().ToList();
            if (measure != null)
               return Ok(measure);
            return Ok();
        }
        [Produces("application/json")]
        public IActionResult GetColor()
        {
            var color =  _categoryRepo.ItemRepo.ColorRepo.GetAsQueryable().ToList();
            if(color!=null)
                return Ok(color);
            return Ok();
        }
        [Produces("application/json")]
        public async Task<ActionResult> Addelement(Item Item)
        {
            await _categoryRepo.ItemRepo.AddEntityAsync(Item);
            var category = _categoryRepo.GetAsQueryable(x => x.CategoryId == Item.CategoryId).FirstOrDefault();
            return Ok(category.CategoryName);
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken] [Bind("itemId,itemName,measurementId,storeId,quantity,priceBuy,priceSale")]
        public async Task<IActionResult> Create(Category categoury)
        {
            if (ModelState.IsValid)
            {
                if (categoury is not null)
                    await _categoryRepo.AddEntityAsync(categoury);
                return RedirectToAction(nameof(Index));
            }
            return View(categoury);
        }
        // GET: Items/Edit/5
        [HttpGet]
        public async  Task<IActionResult> Edit(int id)
        {
            var items =await _categoryRepo.ItemRepo.GetAsQueryable(x=>x.IsDelete==false&&x.ItemId == id).Include(x=>x.Color)
                .Include(x=>x.Measure).FirstOrDefaultAsync();
            ViewBag.measure = _categoryRepo.ItemRepo.MeasureRepo.GetAsQueryable(x => x.IsDelete == false);
            ViewBag.color = _categoryRepo.ItemRepo.ColorRepo.GetAsQueryable(x => x.IsDelete == false);
            return PartialView(items);
        }


        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Produces("application/json")]
        [HttpPost]
        // [ValidateAntiForgeryToken]  [Bind("itemId,itemName,measurementId,storeId,quantity,priceBuy,priceSale")]
        public async Task<IActionResult> Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                try {
                    // _context.ItemDetails.Update(item);
                 await   _categoryRepo.ItemRepo.UpdateEntityAsync(item);
                }
                catch (Exception e)
                {
                   var data= e.Message;
                }
                }

            var itemname =_categoryRepo.GetAsQueryable(x => x.CategoryId == item.CategoryId).FirstOrDefault();
            return Ok(itemname.CategoryName);
        }
        [HttpGet]
        public async Task<IActionResult> EditItemQuantity(int id) => PartialView(await _categoryRepo.ItemRepo.ItemQauntityRepo.GetByIdAsync(id));
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> EditItemQuantity(ItemQuantity itemQuantity)
        {
            await _categoryRepo.ItemRepo.ItemQauntityRepo.UpdateEntityAsync(itemQuantity);
            return Ok();
        }
        public async Task<IActionResult> DeleteItemQuantity(int itemQuantityId)
        {
            await _categoryRepo.ItemRepo.ItemQauntityRepo.DeleteEntityAsync(itemQuantityId);
            return Ok();
        }

        [HttpGet]
        public IActionResult EditName(int id)
        {
            var items =  _categoryRepo.GetAsQueryable(x => x.CategoryId == id).Include(x=>x.Store).FirstOrDefault();
            ViewBag.stores = _categoryRepo.StoreRepo.GetAsQueryable(x => x.IsDelete == false);
            return PartialView(items);
        }
        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> EditName(Category item)
        {
           await  _categoryRepo.UpdateEntityAsync(item);
            return Ok();
        }
        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var items = await _categoryRepo.GetAsQueryable(x=>x.IsDelete==false).Include(i => i.Items).Include(i => i.Store)
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (items == null)
            {
                return NotFound();
            }

            return View();
        }
        [HttpGet]
        public IActionResult CreateItemQuantity() => PartialView();
        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> CreateItemQuantity(ItemQuantity itemQauntity)
        {
            ///need the name
            await _categoryRepo.ItemRepo.ItemQauntityRepo.AddEntityAsync(itemQauntity);
            var categoryName= _categoryRepo.ItemRepo.GetAsQueryable(x => x.ItemId == itemQauntity.ItemId).Include(x => x.Category).FirstOrDefault().Category.CategoryName;
            return Ok(categoryName);
        }
        // POST: Items/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoryRepo.DeleteEntityAsync(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [Produces("application/json")]
        public IActionResult Getbillsnumber(int id) => Ok(_categoryRepo.GetBillsIdFromItemQuantity(x => x.ItemId == id).ToList());
    }
}
