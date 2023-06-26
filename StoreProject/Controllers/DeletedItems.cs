using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreProject.DAL;
using StoreProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StoreProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DeletedItems : Controller
    {
        private BaseEntity<Item> _itemDetailRepo;

        public DeletedItems(BaseEntity<Item> itemRepo)
        {
            _itemDetailRepo = itemRepo;
        }

        // GET: DelitedItems
        public async Task<ActionResult> Index(int?pageNumber,bool isdel)
        {
            var items=_itemDetailRepo.GetAsQueryable(x=>x.IsDelete==true).Include(x=>x.Measure).Include(x=>x.Color).Include(x=>x.Category);
            return View(await PaginatedList<Item>.CreateAsync(items, pageNumber ?? 1, 9));
        }
        //public IActionResult Restore(int id)
        //{
        //    var deleteditems = _context.ItemDetails.Find(id);
        //    var item = _context.Items.Where(x => x.itemId == deleteditems.itemId).FirstOrDefault();
        //    deleteditems.isdel = false;
        //    item.isdel = false;
        //    _context.Update(deleteditems);
        //    _context.Update(item);
        //    _context.SaveChanges();
        //    return Ok();
        //}
    }
}
