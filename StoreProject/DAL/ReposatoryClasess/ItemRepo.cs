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
    /// Deatils of catrgory which define the measure, color and quantity
    /// </summary>
    public class ItemRepo : BaseEntity<Item>
    {
        private readonly OperationHelper _operationHelper;
        /// <summary>
        /// define the color of program
        /// </summary>
        public ColorRepo ColorRepo { get; }
        /// <summary>
        /// define the measure of program
        /// </summary>
        public MeasureRepo MeasureRepo { get; }
        /// <summary>
        ///  Represent the item details which has price and quantity
        /// </summary>
        public ItemQauntityRepo ItemQauntityRepo {  get; }
        /// <summary>
        ///  /// Contractor which use to define the objects with use
        /// </summary>
        /// <param name="operationhelper">deal with database</param>
        /// <param name="itemQauntityRepo">item details which has price and quantity</param>
        /// <param name="colorRepo">define the color of program </param>
        /// <param name="measureRepo">item details which has price and quantity</param>
        public ItemRepo(OperationHelper operationhelper, ItemQauntityRepo itemQauntityRepo, ColorRepo colorRepo, MeasureRepo measureRepo) : base(operationhelper)
        {
            _operationHelper = operationhelper;
            ItemQauntityRepo = itemQauntityRepo;
            ColorRepo = colorRepo;
            MeasureRepo = measureRepo;
        }
        /// <summary>
        /// Get measure  entity as queryable using filter <paramref name="filter"/>
        /// </summary>
        /// <param name="filter">expression func which take Type of item class and return bool</param>
        /// <returns>item entity as queryable</returns>
        public override IQueryable<Item> GetAsQueryable(Expression<Func<Item, bool>> filter=null)
            => CheckNull(filter);
        /// <summary>
        /// Insert item to database
        /// </summary>
        /// <param name="entity">object of item</param>
        /// <returns>Object which inserted to database</returns>
        public override async Task<Item> AddEntityAsync(Item entity)
        {
            var sameItem = GetSameItem(entity, entity.CategoryId);
            if (sameItem is not null)
            {
                if (entity.ItemQuantities.Count > 0)
                    await ItemQauntityRepo.AddListEntities(entity.ItemQuantities, sameItem.ItemId);
            }
            else
            {
                entity.ItemId = CreateId<Item>(x=>x.ItemId);
                var itemQuantities = entity.ItemQuantities;
                entity.ItemQuantities = default;
                await _operationHelper.InsertIntoDbAsync(entity);
                if (itemQuantities.Count > 0)
                    await ItemQauntityRepo.AddListEntities(itemQuantities, entity.ItemId);
            }
            return entity;
        }
        /// <summary>
        /// check if this item is exist or not 
        /// </summary>
        /// <param name="entity">object of item to check </param>
        /// <param name="categoryId"> foreignkey id</param>
        /// <returns>object of item if exist</returns>
        private Item GetSameItem(Item entity, int categoryId) =>
            GetAsQueryable(x => x.IsDelete == false && x.CategoryId == categoryId && x.MeasureId == entity.MeasureId && x.ColorId == entity.ColorId).FirstOrDefault();
        /// <summary>
        /// Insert list of item to database
        /// </summary>
        /// <param name="entities">list of item object</param>
        /// <param name="categoryId"> foreignkey id</param>
        /// <returns>void method</returns>
        public override async Task AddListEntities(List<Item> entities, int categoryId)
        {
            foreach (var entity in entities)
            {
                entity.CategoryId = categoryId;
                await AddEntityAsync(entity);
            }
        }
        /// <summary>
        /// Delete  item from database
        /// </summary>
        /// <param name="id"> id of mesaure object</param>
        /// <returns> boolean as asunchronous</returns>
        public override async Task<bool> DeleteEntityAsync(int id)
        {
            var item = await GetByIdAsync(id);
            item.IsDelete = true;
            foreach (var itemquantity in item.ItemQuantities.Where(x=>!x.IsDelete))
            {
                if (!itemquantity.IsDelete)
                    await ItemQauntityRepo.DeleteEntityAsync(itemquantity.ItemQuantityId);
            }
          return await _operationHelper.UpdateDbAsync(item);
        }
        /// <summary>
        /// Get all items from database 
        /// </summary>
        /// <param name="filter"> expression func which take Type of item  and return bool</param>
        /// <returns> item asqueryable </returns>
        public override IQueryable<Item> GetAll(Expression<Func<Item, bool>> filter)
        {
           var items= GetAsQueryable(filter);
            items.ForEachAsync(x=> x.ItemQuantities=ItemQauntityRepo.GetAsQueryable(i=>i.ItemId==x.ItemId).ToList());
            return items;
        }
        /// <summary>
        /// Get object of item  depend on <paramref name="id"/> 
        /// </summary>
        /// <param name="id">id of item </param>
        /// <returns>object of item </returns>
        public override async Task<Item> GetByIdAsync(int id)
        {
           var item= await GetAsQueryable(x => x.ItemId == id).FirstOrDefaultAsync();
            item.ItemQuantities = ItemQauntityRepo.GetAsQueryable(x => x.ItemId == item.ItemId).ToList();
            return item;
        }
        /// <summary>
        /// Upadate object of item in database
        /// </summary>
        /// <param name="entity"> object of item to update </param>
        /// <returns>void method</returns>
        public override Task UpdateEntityAsync(Item entity) => _operationHelper.UpdateDbAsync(entity);
    }
}
