using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StoreProject.DAL;
using StoreProject.Models;

namespace StoreProject.Controllers
{
    public class BillsController : Controller
    {
        private readonly BaseEntity<Bill> _billRepo;
       private readonly BaseEntity<Brand> _brandRepo;
        public BillsController(BaseEntity<Bill> billRepo, BaseEntity<Brand> brandRepo)
        {
            _billRepo = billRepo;
           _brandRepo = brandRepo;
        }
        [Produces("application/json")]
        public IActionResult GetItemId(String name)
        {
            Category category=null;
        if (name != null)
                 category = _billRepo.CateroryRepo.GetAsQueryable(x => x.CategoryName.Contains(name) && x.IsDelete == false).FirstOrDefault();
            return Ok(category);
        }
        [Produces("application/json")]
        public IActionResult GetStores() => Ok(_billRepo.GetStores(x => !x.IsDelete));
        [Produces("application/json")]
        public IActionResult AutoComplete(String search)
        {
            var items = _billRepo.AutoComplete(x => x.CategoryName.Contains(search) && x.IsDelete == false);
            return Ok(items);
        }
        [Produces("application/json")]
        public IActionResult MeasureFilters(int categoryid,bool isbuy=false)
        {
             List<dynamic> measures = _billRepo.MeasureFilter(x => x.CategoryId == categoryid && !x.IsDelete, isbuy).ToList();
                return Ok(measures);
        }
        [Produces("application/json")]
        public IActionResult ColorFilters(int categoryid, int measureid,bool isbuy=false)
        {
            List<dynamic> colors = _billRepo.ColorFilter(x => x.CategoryId == categoryid && x.MeasureId == measureid&&!x.IsDelete,isbuy).ToList();
            return Ok(colors);
        }
        [Produces("application/json")]
        public  IActionResult SearchBill(String search, bool isbuy = false)
        {
            List<dynamic> data = null;

            bool isok = int.TryParse(search, out int billId);
            if (isok)
                 data = _billRepo.SearchBills(x => x.BillId == billId  && x.IsBuy == isbuy).ToList();
            else
                data = _billRepo.SearchBills(x => x.Customer.Name.Contains(search) && x.IsBuy == isbuy).ToList();
            return Ok(data);
        }
        [Produces("application/json")]
        public IActionResult GetItemData(String itemName)
        {
            TempData.Keep("isbuy");
            var category = _billRepo.CateroryRepo.GetAsQueryable(x => x.CategoryName == itemName&&x.IsDelete==false).FirstOrDefault();
           return Ok(category is not null?category.CategoryId:"");
        }

        [Produces("application/json")]
        public IActionResult GetPrice(int categoryid, int measureid, int colorid)
        {
            TempData.Keep("isbuy");
            var itemQuantity = _billRepo.GetItemQuantityFromItem(x => x.CategoryId == categoryid && x.MeasureId == measureid && x.ColorId == colorid && x.IsDelete == false, Convert.ToBoolean(TempData["isbuy"]));
            return Ok(itemQuantity);
        }
        public async Task<ActionResult> Purchase(int billId)
        {
            TempData.Keep("isbuy");
            var bill = _billRepo.GetBillWithBillItemsWithItemAndColorAndMeasure(x => x.BillId == billId && x.IsBuy == Convert.ToBoolean(TempData["isbuy"]));
            if (bill is not null)
            {
                // ViewBag.pay = _billRepo.PaidAsync(x => x.BillId == billId && x.IsDelete == false && x.IsBuy == buybill).Result;
                var payments = _billRepo.PaymentRepo.GetAsQueryable(x => x.BillId == billId).ToList();
                if (payments is not null)
                    ViewBag.paymentList = payments;
               bill.Pay = payments.Sum(x => x.Pay);
                ViewBag.total = await _billRepo.GetTotalNetAsync(x => x.CustomerId == bill.CustomerId && x.IsBuy == Convert.ToBoolean(TempData["isbuy"]));
                return View(bill);
            }
            return View();
        }
        public async Task<ActionResult> PurchasePrint(int billId) => await Purchase(billId);
        [Produces("application/json")]
        public IActionResult GetBrandImages()
        {
            var brandimage=_brandRepo.GetAsQueryable().Include(x=>x.BrandImages).FirstOrDefault();
            return Ok(brandimage);
        }
        public IActionResult GetPaid(int BillId) => Ok(_billRepo.GetTotalNetAsync(x => x.BillId == BillId && x.IsBuy ==Convert.ToBoolean(TempData["isbuy"])));
        public async Task<IActionResult> Index(int? pageNumber,bool isbuy=false)
        {
            var bills = _billRepo.GetAsQueryable(x => x.IsBuy == isbuy).Include(c=>c.Customer).OrderByDescending(x => x.BillId);
                //List<double> depts = new List<double>();
                //foreach (var bill in bills)
                //    depts.Add(Math.Abs(_billRepo.GetTotalNetAsync(x => x.IsDelete == isdel && x.BillId == bill.BillId)));
                //ViewBag.dept = depts;
                TempData["isbuy"] = isbuy;
                ViewBag.isbuy = isbuy;
                return View(await PaginatedList<Bill>.CreateAsync(bills, pageNumber ?? 1, 9));
            
        }
        public IActionResult Newbill()
        {
            TempData.Keep("isbuy");
            ViewBag.isbuy = Convert.ToBoolean(TempData["isbuy"]);
            return PartialView();
        }
        public  async Task<ActionResult> CreateBill(Bill bill)
        {
            bill.UserName=User.Identity.Name;
            await _billRepo.AddEntityAsync(bill);
            // backup();
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            TempData.Keep("isbuy");
            ViewBag.pay= await  _billRepo.PaidAsync(x => x.BillId == id  && x.IsBuy == Convert.ToBoolean(TempData["isbuy"]));
            var bills= _billRepo.GetBillWithBillItemsWithItemAndColorAndMeasure(x => x.BillId == id, x => x.Quantity > 0);
            return   PartialView(bills);
        }

        public async Task<ActionResult> EditBill(Bill bill)
        {
            TempData.Keep("isbuy");
            await _billRepo.UpdateEntityAsync(bill);
            //backup();
            return Ok();
        }
        [Produces("application/json")]
        [HttpGet]
        public IActionResult CreateDiscard(int id)
        {
            TempData.Keep("isbuy");
            var bill = _billRepo.GetBillWithBillItemsWithItemAndColorAndMeasure(x => x.BillId == id &&x.IsBuy== Convert.ToBoolean(TempData["isbuy"]));
            return PartialView(bill);
        }
        public async Task<IActionResult> CreateDiscard(List<BillItem> billItems)
        {
            //there is no need to pass billId and billItemId for this becuse i will update only
            await _billRepo.BillItemRepo.AddListEntities(billItems);
            return Ok();
        }
        public async Task<IActionResult> DeleteBillItem(int billItemId)
        {
            TempData.Keep("isbuy");
            await _billRepo.BillItemRepo.DeleteEntityAsync(billItemId);
            return Ok();
        }
        public async Task<IActionResult> DeleteitemsAsync(int id)
        {
            if (id != 0 && User.IsInRole("Admin"))
                return Ok(await _billRepo.ItemRepo.ItemRepo.DeleteEntityAsync(id));
            return Ok("غير مصرح لك بالحذف");
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id!=0&&User.IsInRole("Admin"))
                return PartialView(await _billRepo.GetByIdAsync(id));
            return PartialView();
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int billid, bool ReturnBillItemToStore)
        {
            if (ReturnBillItemToStore)
                await _billRepo.DeleteEntityAsync(billid);
            else
                await _billRepo.DeleteAllBillContentWithoutRetreiveDataToStore(billid);
            return RedirectToAction(nameof(Index));
        }
    }
}
