﻿using Microsoft.EntityFrameworkCore;
using StoreProject.DAL.ReposatoryClasess;
using StoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace StoreProject.DAL
{
    ///<include file='Documentaion/BaseEntity.xml' path='docs/members[@name="baseentity"]/BaseEntity/*'/>
    public abstract class BaseEntity<T>  where T :class
    {
        private readonly OperationHelper  _operationHelper;
        
        ///<include file='Documentaion/BaseEntity.xml' path='docs/members[@name="baseentity"]/BaseEntityctor/*'/>
        public BaseEntity(OperationHelper operationHelper) => _operationHelper = operationHelper;
        ///<include file='Documentaion/BaseEntity.xml' path='docs/members[@name="baseentity"]/GetAsQueryable/*'/>
        public abstract IQueryable<T> GetAsQueryable(Expression<Func<T, bool>>  filter = null);
        ///<include file='Documentaion/BaseEntity.xml' path='docs/members[@name="baseentity"]/GetAll/*'/>
        public abstract IQueryable<T> GetAll(Expression<Func<T, bool>> filter);
        ///<include file='Documentaion/BaseEntity.xml' path='docs/members[@name="baseentity"]/GetByIdAsync/*'/>
        public abstract Task<T> GetByIdAsync(int id);
        ///<include file='Documentaion/BaseEntity.xml' path='docs/members[@name="baseentity"]/AddEntityAsync/*'/>
        public abstract Task<T> AddEntityAsync(T entity);
        ///<include file='Documentaion/BaseEntity.xml' path='docs/members[@name="baseentity"]/AddListEntities/*'/>
        public virtual Task AddListEntities(List<T> entities, int entityId) => Task.CompletedTask;
        ///<include file='Documentaion/BaseEntity.xml' path='docs/members[@name="baseentity"]/UpdateEntityAsync/*'/>
        public abstract Task UpdateEntityAsync(T entity);
        ///<include file='Documentaion/BaseEntity.xml' path='docs/members[@name="baseentity"]/DeleteEntityAsync/*'/>
        public abstract Task<bool> DeleteEntityAsync(int id);
        ///<include file='Documentaion/BaseEntity.xml' path='docs/members[@name="baseentity"]/CreateId/*'/>
        protected int CreateId<O>(Func<O, int> filter, int id = 1) where O : class
        => _operationHelper.GetAnyWithoutCondition<O>().Any()?_operationHelper.GetAnyWithoutCondition<O>().Max(filter) + id: 1;
        ///<include file='Documentaion/BaseEntity.xml' path='docs/members[@name="baseentity"]/CheckNull/*'/>
        protected IQueryable<O> CheckNull<O>(Expression<Func<O, bool>> filter) where O : class =>
         filter is null ? _operationHelper.GetAnyWithoutCondition<O>() : _operationHelper.GetAny(filter);     
        ///<include file='Documentaion/BaseEntity.xml' path='docs/members[@name="baseentity"]/MeasureFilter/*'/>
        public IEnumerable<object> MeasureFilter(Expression<Func<Item, bool>> filter = null,bool isbuy=false)
        {
            if (isbuy)
            {
                var measures=CheckNull<Measure>(x=>!x.IsDelete).ToList();
                foreach (var measure in measures)
                {
                    var data = new
                    {
                        measure.MeasureId,
                        measure.MeasureName,
                    };
                    yield return data;
                }
            }
            else
            {
                var items = CheckNull(filter).Include(x => x.Measure).ToList();
                foreach (var item in items.DistinctBy(x => x.MeasureId))
                {
                    var data = new
                    {
                        item.MeasureId,
                        item.Measure.MeasureName,
                    };
                    yield return data;
                }
            }
            yield break;
        }
        ///<include file='Documentaion/BaseEntity.xml' path='docs/members[@name="baseentity"]/GetListOfItems/*'/>
        public IEnumerable<dynamic> GetListOfItems(Expression<Func<Item,bool>> filter,Func<ItemQuantity,bool>filter2)
        {
            var dbitemDetails = GetItemWithMeasureAndColor(filter).ToList();
            if (dbitemDetails.Count>0)
            {
                foreach (var item in dbitemDetails)
                {
                    yield return new
                    {
                      item.ItemId,item.CategoryId, item.MeasureId,item.Measure.MeasureName, item.ColorId,item.Color.ColorName,
                      ItemQuantity = GetItemQuantity(x=>x.ItemId==item.ItemId).Where(filter2).ToList(),
                    };
                }
            }
            yield break;
        }
        ///<include file='Documentaion/BaseEntity.xml' path='docs/members[@name="baseentity"]/PaidAsync/*'/>
        public async Task<double> PaidAsync(Expression<Func<Bill, bool>> filter)
        {
          var bills= await CheckNull(filter).Include(x => x.Payments).ToListAsync();
            return  bills.Select(x => x.Payments.Sum(x => x.Pay)).Sum();
        }

        ///<include file='Documentaion/BaseEntity.xml' path='docs/members[@name="baseentity"]/PaidAsync/*'/>
        public async Task<double> DebitAsync(Expression<Func<Bill, bool>> filter=null)
        {
            var bills = await CheckNull(filter).Include(x => x.BillItems).ToListAsync();
            if (bills.Any())
            {
                double dept=0;
                foreach (var bill in bills)
                {
                    if (bill.IsBuy)
                        dept += bill.BillItems.Sum(y => y.BuyPrice * y.Quantity) - bill.Discount;
                    else
                        dept += bill.BillItems.Sum(y => y.SalePrice * y.Quantity) - bill.Discount;
                }
                return dept;
            }
            else
                return 0;
        }
        ///<include file='Documentaion/BaseEntity.xml' path='docs/members[@name="baseentity"]/ProfitBill/*'/>
        public List<Bill> ProfitBills(Expression<Func<Bill,bool>>func)
        {
            if (func.Parameters.FirstOrDefault().Name=="x")
            {
                List<Bill> billList = new();
                var bill = CheckNull<Bill>(func).Include(x => x.Customer).Include(x => x.BillItems).Include(x => x.Payments).FirstOrDefault();
                bill.BillItems.ForEach(x => x.ItemQantity = GetItemQuantity(i => i.ItemQuantityId == x.ItemQuantityId).FirstOrDefault());
                bill.BillItems.ForEach(x => x.ItemQantity.Item=GetItemWithMeasureAndColor(y=>y.ItemId==x.ItemQantity.ItemId).FirstOrDefault());
                 billList.Add(bill);
                return billList;
            }
            var bills = CheckNull<Bill>(func).Include(x => x.Customer).Include(x => x.BillItems).Include(x => x.Payments).ToList();
            bills.ForEach(b => b.BillItems.ForEach(x => x.ItemQantity = GetItemQuantity(i => i.ItemQuantityId == x.ItemQuantityId).FirstOrDefault()));
            return bills;
        }
        ///<include file='Documentaion/BaseEntity.xml' path='docs/members[@name="baseentity"]/DoubleFormat/*'/>
        public double DoubleFormat(double value) =>
            Double.Parse(value.ToString("0.00"));
        ///<include file='Documentaion/BaseEntity.xml' path='docs/members[@name="baseentity"]/GetTotalNetAsync/*'/>
        public async Task<double> GetTotalNetAsync(Expression<Func<Bill, bool>> filter) => 
           await PaidAsync(filter) - await DebitAsync(filter);
        ///<include file='Documentaion/BaseEntity.xml' path='docs/members[@name="baseentity"]/GetItemquantityAndItemWithColorAndMesureToBillItem/*'/>
        protected List<BillItem> GetItemquantityAndItemWithColorAndMesureToBillItem(Expression<Func<BillItem, bool>> billitem_filter)
        {
           var billItems = CheckNull(billitem_filter).ToList();
            for (int i = 0; i < billItems.Count; i++)
            {
                var itemquantity = CheckNull<ItemQuantity>(x => x.ItemQuantityId == billItems[i].ItemQuantityId).FirstOrDefault();
                itemquantity.Item = GetItemWithMeasureAndColor(x => x.ItemId == itemquantity.ItemId).FirstOrDefault();
               billItems[i].ItemQantity = itemquantity;
            }
            return billItems;
        }
        ///<include file='Documentaion/BaseEntity.xml' path='docs/members[@name="baseentity"]/GetItemWithMeasureAndColor/*'/>
        public IEnumerable<Item> GetItemWithMeasureAndColor(Expression<Func<Item, bool>> filter)
        {
            var items = CheckNull(filter).Include(x => x.Measure).Include(x => x.Color).Select(x => new
            {
                x.ItemId,
                x.ColorId,
                x.MeasureId,
                x.Color,
                x.Measure,
                x.CategoryId,
            }).ToList();

            foreach (var item in items)
            {
                yield return new Item
                {
                    ItemId = item.ItemId,
                    ColorId = item.ColorId,
                    MeasureId = item.MeasureId,
                    Color = item.Color,
                    Measure = item.Measure,
                    CategoryId = item.CategoryId,
                };
            }
            yield break;
        }
        ///<include file='Documentaion/BaseEntity.xml' path='docs/members[@name="baseentity"]/GetItemQuantity/*'/>
        public IEnumerable<ItemQuantity> GetItemQuantity(Expression<Func<ItemQuantity, bool>> filter)
        {
            var itemquantity = CheckNull(filter).Select(x => new
            {
                x.ItemQuantityId,
                x.Quantity,
                x.SalePrice,
                x.BuyPrice,
                x.ItemId,
                x.IsDelete,
            }).ToList();
            foreach (var item in itemquantity)
            {
                    yield return new ItemQuantity
                    {
                        ItemQuantityId = item.ItemQuantityId,
                        ItemId = item.ItemId,
                        Quantity = item.Quantity,
                        IsDelete = item.IsDelete,
                        SalePrice = item.SalePrice,
                        BuyPrice = item.BuyPrice,
                    };
            }
            yield break;
        }
        ///<include file='Documentaion/BaseEntity.xml' path='docs/members[@name="baseentity"]/DeleteAllBillContentWithoutRetreiveDataToStore/*'/>
        public virtual Task<bool> DeleteAllBillContentWithoutRetreiveDataToStore(int id)
            => (Task<bool>)Task.CompletedTask;
        ///<include file='Documentaion/BaseEntity.xml' path='docs/members[@name="baseentity"]/GetBillsIdFromItemQuantity/*'/>
        public IEnumerable<int> GetBillsIdFromItemQuantity(Expression<Func<ItemQuantity, bool>> filter)
        {
            var itemquantities = CheckNull(filter).Select(x=>x.ItemQuantityId).ToList();
            foreach (var item in itemquantities)
            {
                var billid= CheckNull<BillItem>(x => x.ItemQuantityId == item).Select(x => x.BillId).FirstOrDefault();
                if(billid!=0)
                    yield return billid;
            }
            yield break;
        }
        ///<include file='Documentaion/BaseEntity.xml' path='docs/members[@name="baseentity"]/DateTimeNow/*'/>
        public DateTime DateTimeNow() => DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm"));

        public double GetTotalMoneyForStore()
        {
            var payments = _operationHelper.GetAnyWithoutCondition<Payment>().ToList();
            double paied = 0;
            foreach(var payment in payments)
            {
                int exist=_operationHelper.GetAny<Bill>(x=>x.BillId==payment.BillId&&!x.IsBuy).Count();
                if (exist > 0)
                    paied += payment.Pay;
                else
                    paied -= payment.Pay;
            }
            return paied;
        }
    }
}
