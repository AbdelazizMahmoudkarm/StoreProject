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
using StoreProject.DAL.ReposatoryClasess;

namespace StoreProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DeletedItems : Controller
    {
        private readonly ItemRepo _itemDetailRepo;
        public DeletedItems(ItemRepo itemRepo) => _itemDetailRepo = itemRepo;

        // GET: DelitedItems
        public async Task<ActionResult> Index(int?pageNumber)
        {
            var items=_itemDetailRepo.GetAsQueryable(x=>x.IsDelete==true).Include(x=>x.Measure).Include(x=>x.Color).Include(x=>x.Category);
            return View(await PaginatedList<Item>.CreateAsync(items, pageNumber ?? 1, 9));
        }
    }
}
