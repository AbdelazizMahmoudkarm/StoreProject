using Microsoft.EntityFrameworkCore;
using StoreProject.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using StoreProject.DAL.ReposatoryClasess;
using System.Collections.Generic;

namespace StoreProject.DAL
{

    ///<include file='Documentaion/BillRepo.xml' path='docs/members[@name="billRepo"]/BillRepo/*'/>
    public class BillRepo : BaseEntity<Bill>
    {
        private readonly OperationHelper _operationHelper;
        ///<include file='Documentaion/BillRepo.xml' path='docs/members[@name="billRepo"]/BillItemRepo/*'/>
        public  BillItemRepo    BillItemRepo    { get;}
        ///<include file='Documentaion/BillRepo.xml' path='docs/members[@name="billRepo"]/CustomerRepo/*'/>
        public  CustomerRepo    CustomerRepo    { get;}
        ///<include file='Documentaion/BillRepo.xml' path='docs/members[@name="billRepo"]/PaymentRepo/*'/>
        public  PaymentRepo  PaymentRepo    { get;}
        ///<include file='Documentaion/BillRepo.xml' path='docs/members[@name="billRepo"]/CateroryRepo/*'/>
        public  CategoryRepo CateroryRepo { get;}
        ///<include file='Documentaion/BillRepo.xml' path='docs/members[@name="billRepo"]/BillRepo_ctor/*'/>
        public BillRepo(BillItemRepo billItemrepo, OperationHelper operationHelper, CustomerRepo customerRepo,
        PaymentRepo paymentRepo, CategoryRepo categoryRepo) : base(operationHelper)
        {
            _operationHelper = operationHelper;
            BillItemRepo = billItemrepo;
            CustomerRepo = customerRepo;
            PaymentRepo = paymentRepo;
            CateroryRepo = categoryRepo;
        }

        ///<include file='Documentaion/BillRepo.xml' path='docs/members[@name="billRepo"]/GetAsQueryable/*'/>
        public override IQueryable<Bill> GetAsQueryable(Expression<Func<Bill, bool>> filter=default) =>
        CheckNull(filter);

        ///<include file='Documentaion/BillRepo.xml' path='docs/members[@name="billRepo"]/AddEntityAsync/*'/>
        public override async Task<Bill> AddEntityAsync(Bill entity)
        {
            if (entity is not null)
            {
                var customer = CustomerRepo.GetAsQueryable(x => x.Name == entity.Customer.Name);
                if (customer.Any())
                {
                    entity.CustomerId = customer.FirstOrDefault().CustomerId;
                    entity.Customer = default;
                }
                else
                {
                    entity.CustomerId =CreateId<Customer>(x=>x.CustomerId);
                    entity.Customer.CustomerId = entity.CustomerId;
                    entity.Customer.Name= entity.Customer.Name.Trim();
                    await CustomerRepo.AddEntityAsync(entity.Customer);
                }
                    entity.CreationDateTime = DateTimeNow();
                
                entity.BillId = CreateId<Bill>(x=>x.BillId);
                entity.CreationDateTime = DateTimeNow();
                var billItems = entity.BillItems;
                entity.BillItems = default;
                await _operationHelper.InsertIntoDbAsync(entity);
                if (billItems is not null)
                {
                    if (billItems?.Count > 0)
                    {
                        if (entity.IsBuy)
                            await BillItemRepo.CreateBuy(billItems, entity.BillId);
                        else
                            await BillItemRepo.AddListEntities(billItems, entity.BillId);
                    }
                }
                if (entity.Pay != 0)
                {
                   await PaymentRepo.AddEntityAsync(new Payment
                   {
                       BillId = entity.BillId,
                       Pay = entity.Pay,
                   });
                }   
            }
            return entity;
        }
        ///<include file='Documentaion/BillRepo.xml' path='docs/members[@name="billRepo"]/UpdateEntityAsync/*'/>
        public override async Task<bool> UpdateEntityAsync(Bill entity)
        {
            var storeBill =await GetAsQueryable(x => x.BillId == entity.BillId).FirstOrDefaultAsync();
            if (storeBill is not null)
            {
                storeBill.Discount = entity.Discount;
                if (entity.BillItems is not null)
                {
                    if (entity.BillItems.Count > 0)
                    {
                        if (entity.IsBuy)
                            await BillItemRepo.CreateBuy(entity.BillItems, entity.BillId);
                        else
                            await BillItemRepo.AddListEntities(entity.BillItems, entity.BillId);
                    }
                }
                if (entity.Customer is not null)
                    await CustomerRepo.UpdateEntityAsync(entity.Customer);
                if (entity.Pay != 0)
                {
                    await PaymentRepo.AddEntityAsync(new Payment()
                    {
                        BillId = entity.BillId,
                        Pay = entity.Pay
                    });
                }
              return  await _operationHelper.UpdateDbAsync(storeBill);
            }
            return false;
        }
        ///<include file='Documentaion/BillRepo.xml' path='docs/members[@name="billRepo"]/DeleteEntityAsync/*'/>
        public override async Task<bool> DeleteEntityAsync(int id)
        {
            var storedbill = await GetAsQueryable(x => x.BillId == id).Include(x=>x.BillItems).FirstOrDefaultAsync();
                foreach (var billItemid in storedbill.BillItems.Select(x => x.BillItemId))
                    await BillItemRepo.RetriveDatatoItemQuantityAsync(billItemid,storedbill.IsBuy);
            if (GetAsQueryable(x => x.CustomerId == storedbill.CustomerId)?.Count() == 1)
              return  await CustomerRepo.DeleteEntityAsync(storedbill.CustomerId);
            return await _operationHelper.DeleteAsync(storedbill);
        }
        ///<include file='Documentaion/BillRepo.xml' path='docs/members[@name="billRepo"]/GetAll/*'/>
        public override IQueryable<Bill> GetAll(Expression<Func<Bill, bool>> filter)
          =>GetAsQueryable(filter).Include(b => b.Customer).OrderByDescending(x => x.BillId);

        ///<include file='Documentaion/BillRepo.xml' path='docs/members[@name="billRepo"]/AutoComplete/*'/>
        public List<Category> AutoComplete(Expression<Func<Category, bool>> filter)
       => CheckNull(filter).Select(x => new Category { CategoryName = x.CategoryName, CategoryId = x.CategoryId }).ToList();

        ///<include file='Documentaion/BillRepo.xml' path='docs/members[@name="billRepo"]/GetByIdAsync/*'/>
        public override async Task<Bill> GetByIdAsync(int id)
        {
            var storebill = await GetAsQueryable(x => x.BillId == id ).Include(x => x.Customer).Include(x => x.Payments).FirstOrDefaultAsync();
            if (storebill is not null)
                storebill.BillItems = BillItemRepo.GetAsQueryable(x => x.BillId == id && x.Quantity != 0)
                    .Include(x => x.ItemQantity.Item.Measure).Include(x => x.ItemQantity.Item.Color).ToList();
            return storebill;
        }

        ///<include file='Documentaion/BillRepo.xml' path='docs/members[@name="billRepo"]/SearchBills/*'/>
        public  IEnumerable<object> SearchBills(Expression<Func<Bill, bool>> filter)
        {
            var bills = CheckNull(filter).Include(x => x.Customer).ToList();
            if (bills is not null)
            {
                foreach (var bill in bills)
                {
                    var item = new
                    {
                        billId = bill.BillId,
                        date = bill.CreationDateTime,
                        name = bill.Customer.Name,
                    };
                    yield return item;
                }
            }
            yield break;
        }

        ///<include file='Documentaion/BillRepo.xml' path='docs/members[@name="billRepo"]/GetStores/*'/>
        public  List<Store> GetStores(Expression<Func<Store, bool>> filter) => CheckNull(filter).ToList();

        ///<include file='Documentaion/BillRepo.xml' path='docs/members[@name="billRepo"]/ColorFilter/*'/>
        public  IEnumerable<object> ColorFilter(Expression<Func<Item, bool>> filter = null, bool isbuy = false)
        {
            if (isbuy)
            {
                foreach (var color in CheckNull<Color>(x => !x.IsDelete).ToList())
                {
                    var data = new
                    {
                        color.ColorId,
                        color.ColorName,
                    };
                    yield return data;
                }
            }
            else
            {
                var items = CheckNull(filter).Include(x => x.Color).ToList();
                foreach (var item in items.DistinctBy(x => x.ColorId))
                {
                    var data = new
                    {
                        item.ColorId,
                        item.Color.ColorName,
                        item.ItemId
                    };
                    yield return data;
                }
            }
            yield break;
        }
        ///<include file='Documentaion/BillRepo.xml' path='docs/members[@name="billRepo"]/GetItemQuantityFromItem/*'/>
        public  ItemQuantity GetItemQuantityFromItem(Expression<Func<Item, bool>> filter = default, bool isbuy = false)
        {
            var item = CheckNull(filter).FirstOrDefault();
            if (item is null)
                return default;
            if (isbuy)
               return GetItemQuantity(x => x.ItemId == item.ItemId).MaxBy(x=>x.Quantity);
            
            return GetItemQuantity(x => x.ItemId == item.ItemId && x.Quantity > 0).MaxBy(x=>x.Quantity);
        }

        ///<include file='Documentaion/BillRepo.xml' path='docs/members[@name="billRepo"]/GetBillWithBillItemsWithItemAndColorAndMeasure/*'/>
        public Bill GetBillWithBillItemsWithItemAndColorAndMeasure(Expression<Func<Bill, bool>> bill_filter, Func<BillItem, bool> billItem_filter = default)
        {
            var bill = CheckNull(bill_filter).Include(x => x.Customer).Include(x => x.Payments).FirstOrDefault();
            if (bill is not null)
            {
                if (billItem_filter is null)
                    bill.BillItems = GetItemquantityAndItemWithColorAndMesureToBillItem(x => x.BillId == bill.BillId).ToList();
                else
                    bill.BillItems = GetItemquantityAndItemWithColorAndMesureToBillItem(x => x.BillId == bill.BillId).Where(billItem_filter).ToList();
                return bill;
            }
            else
                return default;
        }
        ///<include file='Documentaion/BillRepo.xml' path='docs/members[@name="billRepo"]/DeleteAllBillContentWithoutRetreiveDataToStore/*'/>
        public override async Task<bool> DeleteAllBillContentWithoutRetreiveDataToStore(int id)
            =>await _operationHelper.DeleteAsync(await CheckNull<Bill>(x => x.BillId == id).FirstOrDefaultAsync());
    }
}
