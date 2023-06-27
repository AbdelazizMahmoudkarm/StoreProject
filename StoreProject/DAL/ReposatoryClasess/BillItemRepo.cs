using Microsoft.EntityFrameworkCore;
using StoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StoreProject.DAL.ReposatoryClasess
{
    /// <summary>
    /// Use to insert, retrive, update and delete the bill details 
    /// </summary>
    public class BillItemRepo : BaseEntity<BillItem>
    {
        private readonly OperationHelper _operationHelper;
        /// <summary>
        /// Has the some deatails about the store such as price and quantity
        /// </summary>
        public  ItemQauntityRepo ItemQauntityRepo {  get; }
        /// <summary>
        /// It represnt the store which has the name of items
        /// </summary>
        public  CategoryRepo CateroryRepo { get; }
        /// <summary>
        /// Generate the objects using dependancy injection such as:  <paramref name="cateroryRepo"/>, <paramref name="itemQauntity"/><paramref name="operationHelper"/>
        /// and pass the OperationHelper to base class
        /// </summary>
        /// <param name="operationHelper"></param>
        /// <param name="itemQauntity"></param>
        /// <param name="cateroryRepo"></param>
        public BillItemRepo(OperationHelper operationHelper, ItemQauntityRepo itemQauntity, CategoryRepo cateroryRepo) : base(operationHelper)
        {
            _operationHelper = operationHelper;
            ItemQauntityRepo = itemQauntity;
            CateroryRepo = cateroryRepo;
        }
        /// <summary>
        /// Get bill item as queryable using filter <paramref name="filter"/> type of expression func which take Type of bill item class and return bool.
        /// </summary>
        /// <param name="filter"> expression func which take Type of bill item class and return bool</param>
        /// <returns>billitem as queryable</returns>
        public override IQueryable<BillItem> GetAsQueryable(Expression<Func<BillItem, bool>> filter=null) =>
           CheckNull<BillItem>(filter);
        /// <summary>
        /// Get true if is buy else false  
        /// </summary>
        /// <param name="filter"></param>
        /// <returns> bool of buy or not </returns>
        private bool CheckIfBuyBill(Expression<Func<Bill, bool>> filter)
       => _operationHelper.GetAny<Bill>(filter).Select(x => x.IsBuy).FirstOrDefault();
        /// <summary>
        /// Insert Bill item entity in database as a parameter
        /// </summary>
        /// <param name="entity">type of bill item object</param>
        /// <returns>object entity </returns>
        public override async Task<BillItem> AddEntityAsync(BillItem entity)
        {
            bool isOk;
            if (CheckIfBuyBill(x => x.BillId == entity.BillId))
                isOk = await ItemQauntityRepo.PlusQuantityAsync(entity.ItemQuantityId, entity.Quantity);
            else
                isOk = await ItemQauntityRepo.MinusQuantityAsync(entity.ItemQuantityId, entity.Quantity);
            if (isOk)
            {
                entity.BillItemId = CreateId<BillItem>(x=>x.BillItemId);
                await _operationHelper.InsertIntoDbAsync(entity);
        }
            return entity;
        }
        /// <summary>
        /// Update bill item entity to databse
        /// </summary>
        /// <param name="entity"> type of bill item object </param>
        /// <returns> void method</returns>
        public override async Task UpdateEntityAsync(BillItem entity)
        {

            if (entity.BillItemId != 0)
            {
                var existBillIItem = await GetByIdAsync(entity.BillItemId);
                if (existBillIItem is not null)
                {
                    //if there is discardquantity 
                    if (entity.DiscardQuantity > 0)
                    {
                        bool isOk;
                        if (CheckIfBuyBill(x => x.BillId == entity.BillId))
                            isOk = await ItemQauntityRepo.MinusQuantityAsync(entity.ItemQuantityId, entity.DiscardQuantity);
                        else
                            isOk = await ItemQauntityRepo.PlusQuantityAsync(entity.ItemQuantityId, entity.DiscardQuantity);
                        if (isOk)
                        {
                            existBillIItem.DiscardQuantity += entity.DiscardQuantity;
                            existBillIItem.Quantity -= entity.DiscardQuantity;
                            await _operationHelper.UpdateDbAsync(existBillIItem);
                        }
                    }
                        
                    else if (entity.ItemName != existBillIItem.ItemName || entity.SalePrice != existBillIItem.SalePrice)
                    {
                        existBillIItem.SalePrice = entity.SalePrice;
                        existBillIItem.ItemName = entity.ItemName;
                        await _operationHelper.UpdateDbAsync(existBillIItem);
                    }
                }
            }
            else
            {
                var oldBillItem = GetAsQueryable(x => x.ItemQuantityId == entity.ItemQuantityId && x.BillId == entity.BillId).FirstOrDefault();
                if (oldBillItem is not null)
                {
                    bool isOk;
                    if (CheckIfBuyBill(x => x.BillId == entity.BillId))
                        isOk = await ItemQauntityRepo.PlusQuantityAsync(entity.ItemQuantityId, entity.Quantity);
                    else if (oldBillItem.SalePrice == entity.SalePrice) 
                    {
                        isOk = await ItemQauntityRepo.MinusQuantityAsync(entity.ItemQuantityId, entity.Quantity);
                        if (isOk)
                        {
                            oldBillItem.ItemName = entity.ItemName;
                            oldBillItem.Quantity += entity.Quantity;
                            await _operationHelper.UpdateDbAsync(oldBillItem);
                        }
                    }
                    else
                        await AddEntityAsync(entity);
                }
                else
                    await AddEntityAsync(entity);
            }
        }
        /// <summary>
        /// Insert list of bill item entity to database
        /// </summary>
        /// <param name="entities"> list of entities of bill item </param>
        /// <param name="billId"> the id of bill  which inserted to database</param>
        /// <returns>void method</returns>
        public override async Task AddListEntities(List<BillItem> entities, int billId=0)
        {
             foreach (var entity in entities)
            {
                entity.ItemName=entity.ItemName.Trim();
                entity.BillId = billId==0?entity.BillId:billId;
                if (entity.BillItemId != 0 || billId != 0)
                    await UpdateEntityAsync(entity);
                else
                    await AddEntityAsync(entity);
            }
        }
        /// <summary>
        /// Insert or update list of bill items if  isbuy equal true
        /// </summary>
        /// <param name="entities"> list of entities of bill item</param>
        /// <param name="billId"> the id of bill  which inserted to database</param>
        /// <returns> void method</returns>
        public async Task CreateBuy(List<BillItem> entities, int billId)
        {
            foreach (var entity in entities)
            {
                entity.BillId = billId;
                //getting the id of itemquantity;
                var categouryId = _operationHelper.GetAny<Category>(x => x.CategoryName == entity.ItemName.Trim().ToUpper()).Select(x => x.CategoryId).FirstOrDefault();
                if (categouryId != 0)
                {
                    var itemId = _operationHelper.GetAny<Item>(x => x.CategoryId == categouryId && x.MeasureId == entity.MeasureId && x.ColorId == entity.ColorId)
                        .Select(x => x.ItemId).FirstOrDefault();
                    if (itemId != 0)
                    {
                        var itemQuantityId = _operationHelper.GetAny<ItemQuantity>(x => x.Item.ItemId == itemId && x.SalePrice == entity.SalePrice && x.BuyPrice == entity.BuyPrice)
                        .Select(x => x.ItemQuantityId).FirstOrDefault();

                        if (itemQuantityId != 0)
                            entity.ItemQuantityId = itemQuantityId;
                        else
                            entity.ItemQuantityId = GetItemQauntityId();
                    }
                    else
                        entity.ItemQuantityId = GetItemQauntityId();
                }
                else
                    entity.ItemQuantityId = GetItemQauntityId();

                if (entity.BillItemId == 0)
                {
                    await CreateCategory(entity);
                    await AddEntityAsync(entity);
                }
                else
                {
                    await CreateCategory(entity);
                    await UpdateEntityAsync(entity);
                }
            }
        }
        private int GetItemQauntityId()
       =>CreateId<ItemQuantity>(x => x.ItemQuantityId);
        private async Task CreateCategory(BillItem entity)
        => await CateroryRepo.AddEntityAsync(new Category
            {
                CategoryName = entity.ItemName,
                StoreId = entity.StoreId != 0 ?entity.StoreId : 1,
                Items = new List<Item>
                {  
                     new Item
                     {
                         ColorId=entity.ColorId,
                         MeasureId=entity.MeasureId,
                         ItemQuantities=new List<ItemQuantity>
                         {
                             new ItemQuantity
                             {
                                 SalePrice=entity.SalePrice,
                                 BuyPrice=entity.BuyPrice,
                             }
                         }
                     }
                }
            });
        /// <summary>
        /// Return item Quantity from bill to store
        /// </summary>
        /// <param name="id"> the id of item which you want to return it </param>
        /// <param name="isbuy">Boolean parameter for check if item is buy or not</param>
        /// <returns> void method></returns>
        public async Task RetriveDatatoItemQuantityAsync(int id,bool isbuy)
        {
            var billItem = await GetByIdAsync(id);
            if (billItem is not null)
            {
                if (billItem.Quantity != 0&&!isbuy)
                   await ItemQauntityRepo.PlusQuantityAsync(billItem.ItemQuantityId, billItem.Quantity);
                else
                    await ItemQauntityRepo.MinusQuantityAsync(billItem.ItemQuantityId, billItem.Quantity);
            }
        }
        /// <summary>
        /// Delete data after reurn quantity to store
        /// </summary>
        /// <param name="id"></param>
        /// <returns> boolean as asynchronous </returns>
        public override async Task<bool> DeleteEntityAsync(int id)
        {
              var billItem = await GetByIdAsync(id);
            if (billItem is not null)
            {
                if (billItem.Quantity == 0)
                    return await _operationHelper.DeleteAsync(billItem);
                else
                {
                    bool isOk = false;

                    if (await _operationHelper.GetAny<Bill>(x => x.BillId == billItem.BillId).Select(x => x.IsBuy).FirstOrDefaultAsync())
                        isOk = await ItemQauntityRepo.MinusQuantityAsync(billItem.ItemQuantityId, billItem.Quantity);
                    else
                        isOk = await ItemQauntityRepo.PlusQuantityAsync(billItem.ItemQuantityId, billItem.Quantity);
                    if (isOk)
                        return await _operationHelper.DeleteAsync(billItem);
                }
            }
            return false;
        }
        /// <summary>
        /// Get bill item data form database based on condition of <paramref name="filter"/>
        /// </summary>
        /// <param name="filter"> type of expression of delegate Func which take billitem and return boolean </param>
        /// <returns> bill item as queryable</returns>
        public override IQueryable<BillItem> GetAll(Expression<Func<BillItem, bool>> filter) => GetAsQueryable(filter);
        /// <summary>
        /// Get the object of bill item depend on <paramref name="id"/> of bill item 
        /// </summary>
        /// <param name="id"> the id of bill item</param>
        /// <returns>object of bill item</returns>
        public override async Task<BillItem> GetByIdAsync(int id) =>
            await GetAsQueryable(x => x.BillItemId == id).FirstOrDefaultAsync();
    }
}
