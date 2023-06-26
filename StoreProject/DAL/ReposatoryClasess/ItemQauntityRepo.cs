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
    /// Represent the item details which has price and quantity
    /// </summary>
    public class ItemQauntityRepo : BaseEntity<ItemQuantity>
    {
        private readonly OperationHelper _operationHelper;
        /// <summary>
        /// Contractor which use to define the objects with use 
        /// </summary>
        /// <param name="operationHelper"></param>
        public ItemQauntityRepo(OperationHelper operationHelper) : base(operationHelper) => _operationHelper = operationHelper;
        /// <summary>
        /// Get  entity as queryable using filter <paramref name="filter"/>
        /// </summary>
        /// <param name="filter">expression func which take Type of item quantity class and return bool</param>
        /// <returns> entity as queryable</returns>
        public override IQueryable<ItemQuantity> GetAsQueryable(Expression<Func<ItemQuantity, bool>> filter) =>
          CheckNull(filter);
        /// <summary>
        /// Insert enity to database
        /// </summary>
        /// <param name="entity">object of item quantity</param>
        /// <returns>Object which inserted to database</returns>
        public override async Task<ItemQuantity> AddEntityAsync(ItemQuantity entity)
        {
            entity.ItemQuantityId = CreateId<ItemQuantity>(x=>x.ItemQuantityId);
            await _operationHelper.InsertIntoDbAsync(entity);
            return entity;
        }
        /// <summary>
        /// Upadate object of enity in database
        /// </summary>
        /// <param name="entity"> object of item quantity to update </param>
        /// <returns>void method</returns>
        public override async Task UpdateEntityAsync(ItemQuantity entity)=>
            await _operationHelper.UpdateDbAsync(entity);
        /// <summary>
        /// Insert List of itemquantity  to database
        /// </summary>
        /// <param name="entities">list of item quantity</param>
        /// <param name="entityid">the foreignkey of item </param>
        /// <returns> void method</returns>
        public override async Task AddListEntities(List<ItemQuantity> entities, int entityid)
        {
            foreach (var entity in entities)
            {
                var sameItemquantity = GetAsQueryable(x => x.ItemId == entityid && x.SalePrice == entity.SalePrice && x.BuyPrice == entity.BuyPrice).FirstOrDefault();
                if (sameItemquantity is not null)
                {
                    sameItemquantity.IsDelete = false;
                    sameItemquantity.Quantity += entity.Quantity;
                    await UpdateEntityAsync (sameItemquantity);
                }
                else
                {
                    entity.ItemId = entityid;
                    await AddEntityAsync(entity);
                }
            }
        }
        /// <summary>
        /// Delete entity from database
        /// </summary>
        /// <param name="id"> id of item quantity object</param>
        /// <returns> boolean as asunchronous</returns>
        public override async Task<bool> DeleteEntityAsync(int id)
        {
            var itemquantity =await GetByIdAsync(id);
            if (!itemquantity.IsDelete)
            {
                itemquantity.IsDelete = true;
                itemquantity.Quantity = 0;
                return await _operationHelper.UpdateDbAsync(itemquantity);
            }
            else
                return false;
        }
        /// <summary>
        /// Get all item quantity from database depend on filter<paramref name="filter"/>
        /// </summary>
        /// <param name="filter"> expression func which take Type of item quantity  and return bool</param>
        /// <returns> item quantity asqueryable </returns>
        public override  IQueryable<ItemQuantity> GetAll(Expression<Func<ItemQuantity, bool>> filter) =>  GetAsQueryable(filter);
        /// <summary>
        /// Get object of enity  depend on <paramref name="id"/> 
        /// </summary>
        /// <param name="id">id of item quantity </param>
        /// <returns>object of quantity </returns>
        public override async Task<ItemQuantity> GetByIdAsync(int id) => await GetAsQueryable(x => x.ItemQuantityId == id).FirstOrDefaultAsync();
      /// <summary>
      /// Add quantity to item quantity
      /// </summary>
      /// <param name="itemquantityId"> the id of item quantity object to add quantity</param>
      /// <param name="quantity">The quantity to add to item quantity</param>
      /// <returns> boolean as asynchronous</returns>
        public async Task<bool> PlusQuantityAsync(int itemquantityId, double quantity)
        {
            var itemQuantity = await GetByIdAsync(itemquantityId);
            if (itemQuantity is not null)
            {
                itemQuantity.Quantity += quantity;
                itemQuantity.IsDelete = false;
                    await UpdateEntityAsync(itemQuantity);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Subtract quantity from item quantity
        /// </summary>
        /// <param name="itemquantityId"> the id of item quantity object to subtract quantity</param>
        /// <param name="quantity">The quantity to subtract from item quantity</param>
        /// <returns> boolean as asynchronous</returns>
        public async Task<bool> MinusQuantityAsync(int itemquantityId, double quantity)
        {
            var itemQuantity = await GetByIdAsync(itemquantityId);
            if (itemQuantity is not null )
            {
                if (itemQuantity.Quantity >= quantity)
                {
                    itemQuantity.Quantity -= quantity;
                    await UpdateEntityAsync(itemQuantity);
                    return true;
                }
            }
            return false;
        }
    }
}
