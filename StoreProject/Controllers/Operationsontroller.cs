using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreProject.DAL;
namespace StoreProject.Models
{
    [Authorize(Roles = "Admin")]
    public class OperationsController : Controller
    {
        private readonly BillRepo _billRepo;
        public OperationsController(BillRepo billRepo)=>
            _billRepo = billRepo;
   
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LowCountItems(string number)
        {
            List<ItemQuantity> itemQuantities;
            if (number != null && int.TryParse(number, out int num))
            {
                TempData["num"] = num;

                itemQuantities = _billRepo.GetItemQuantity(q => !q.IsDelete && q.Quantity <= num).ToList();
                itemQuantities.ForEach(q => q.Item = _billRepo.GetItemWithMeasureAndColor(i => i.ItemId == q.ItemId).FirstOrDefault());
                itemQuantities.ForEach(q => q.Item.Category = _billRepo.CateroryRepo.GetByIdAsync(q.Item.CategoryId).Result);
            }
            else
            {
                itemQuantities = _billRepo.GetItemQuantity(q => !q.IsDelete).ToList();
                itemQuantities.ForEach(q => q.Item = _billRepo.GetItemWithMeasureAndColor(i => i.ItemId == q.ItemId).FirstOrDefault());
                itemQuantities.ForEach(q => q.Item.Category = _billRepo.CateroryRepo.GetByIdAsync(q.Item.CategoryId).Result);
            }
            return PartialView(itemQuantities);
        }
        public IActionResult CountItems()
        {
            ///buyprice or ssale price
            var totalPrice = _billRepo.CateroryRepo.ItemRepo.ItemQauntityRepo.
                GetAsQueryable(x => x.IsDelete == false && x.Quantity > 0).Sum(x => x.BuyPrice * x.Quantity);
            return PartialView(_billRepo.DoubleFormat(totalPrice));
        }
        public IActionResult CalcBilsWithDate(string date, string date2)
        {
           var isok1= DateTime.TryParse(date, out DateTime formDateTime);
           var isok2= DateTime.TryParse(date2,out DateTime toDateTime);
            if (isok1 && isok2)
            {
                var bills = _billRepo.GetAsQueryable(x => x.CreationDateTime >= formDateTime && x.CreationDateTime <= toDateTime && !x.IsBuy).Include(x => x.Customer).ToList();
                bills.ForEach(b => b.BillItems = _billRepo.BillItemRepo.GetAsQueryable(i => i.BillId == b.BillId).ToList());
                bills.ForEach(b => b.Payments = _billRepo.PaymentRepo.GetAsQueryable(p => p.BillId == b.BillId).ToList());
                bills.ForEach(b => b.BillItems.ForEach(x => x.ItemQantity = _billRepo.GetItemQuantity(i => i.ItemQuantityId == x.ItemQuantityId).FirstOrDefault()));
                return PartialView(bills);
            }
            return PartialView();
        }
        public async Task<IActionResult> Findbill(int id)
        {
            var bill= _billRepo.ProfitBill(id);
            bill.Pay =await  _billRepo.PaidAsync(x=>x.BillId == id);
            ViewBag.totalearn = bill.BillItems.Sum(b=>b.SalePrice*b.Quantity - (b.ItemQantity.BuyPrice*b.Quantity))- bill.Discount;
            return PartialView(bill);
        }
        public IActionResult Day()
        {
            var paid = _billRepo.PaymentRepo.GetAll(x=>x.Date== _billRepo.DateTimeNow()).Sum(x=>x.Pay);
            return PartialView(paid);

        }
        //public IActionResult restore()
        //{

        //    //System.IO.OpenFileDialog d = new OpenFileDialog();
        //    //d.Filter = "bak files (*.bak)|*.bak";
        //    //// d.ShowDialog();
        //    //if (d.ShowDialog() == DialogResult.OK)
        //    //{

        //    //}
        //    //_context.Database.CloseConnection();
        //    //_context.Database.ExecuteSqlCommand("RESTORE DATABASE Elphateh FROM  DISK ='D://data/dd.bak' with replace");
        //    return Ok();
        //}
        public async Task<IActionResult> Dept()
        {
            var dept =await  _billRepo.DebitAsync();
            return PartialView(dept);
        }
        public IActionResult Calpercent()
        {
            return PartialView();
        }
        //public void Backup()
        //{
        //    if (!System.IO.Directory.Exists(@"D:\data"))
        //        System.IO.Directory.CreateDirectory(@"D:\data");
        //    if (!System.IO.Directory.Exists(@"D:\data\" + DateTime.Now.Year.ToString()))
        //        System.IO.Directory.CreateDirectory(@"D:\data\" + DateTime.Now.Year.ToString());
        //    if (!System.IO.Directory.Exists(@"D:\data\" + DateTime.Now.Year.ToString() + "\\" + DateTime.Now.Month.ToString()))
        //        System.IO.Directory.CreateDirectory(@"D:\data\" + DateTime.Now.Year.ToString() + "\\" + DateTime.Now.Month.ToString());
        //    string filename = String.Format("{0}__{1}", Customedate(), "محذوفه.bak" + "'");
        //    //_context.Database.ExecuteSqlCommand("BACKUP DATABASE Elphateh TO  DISK ='D://data/" + DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + filename);
        //}
        [Produces("application/json")]
        public async Task<IActionResult> ChangeItemQuantity(ItemQuantity itemquantity)
        {
            if (itemquantity is not null)
            {
                var itemQuantity = await _billRepo.CateroryRepo.ItemRepo.ItemQauntityRepo.GetByIdAsync(itemquantity.ItemQuantityId);
                itemQuantity.BuyPrice = itemquantity.BuyPrice;
                itemQuantity.SalePrice=itemquantity.SalePrice;
                itemQuantity.Quantity = itemquantity.Quantity;
                await _billRepo.CateroryRepo.ItemRepo.ItemQauntityRepo.UpdateEntityAsync(itemQuantity);
                return Ok(true);
            }
            return Ok(false);
        }
        public String Customedate()
        {
            var hour = DateTime.Now.Hour;
            var datenow = DateTime.Now;
            string date;
            if (hour > 12)
                date = datenow.Day + "----" + (hour - 12) + "-" + datenow.Minute + "-" + datenow.Second + "م";
            else if (hour == 12)
                date = datenow.Day + "----" + hour + "-" + datenow.Minute + "-" + datenow.Second + "م";
            else
                date = datenow.Day + "----" + hour + "-" + datenow.Minute + "-" + datenow.Second + "ص";
            return date;
        }
    }
}
