using Microsoft.EntityFrameworkCore;
using StoreProject.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StoreProject.DAL.ReposatoryClasess
{
    /// <summary>
    /// Represent the data in the store
    /// </summary>
    public class CategoryRepo : BaseEntity<Category>
    {
        private readonly OperationHelper _operationHelper;
        /// <summary>
        /// The details of the store which contain the color, measure and some other details 
        /// </summary>
        public  ItemRepo ItemRepo {  get; }
        /// <summary>
        /// Represent the name of stores
        /// </summary>
        public  StoreRepo StoreRepo { get; }
        /// <summary>
        /// Constractor which use to define <paramref name="itemRepo"/> <paramref name="operationHelper"/><paramref name="storeRepo"/> to constract our object 
        /// </summary>
        /// <param name="operationHelper"> use to deal with database</param>
        /// <param name="itemRepo">contain details about the store</param>
        /// <param name="storeRepo"> represent the store name</param>
        public CategoryRepo(OperationHelper operationHelper, ItemRepo itemRepo, StoreRepo storeRepo) : base(operationHelper)
        {
            _operationHelper = operationHelper;
            ItemRepo = itemRepo;
            StoreRepo = storeRepo;
        }
        /// <summary>
        /// Get category entity as queryable using filter <paramref name="filter"/>
        /// </summary>
        /// <param name="filter">expression func which take Type of category class and return bool</param>
        /// <returns>category entity as queryable</returns>
        public override IQueryable<Category> GetAsQueryable(Expression<Func<Category, bool>> filter=null) =>
           CheckNull(filter);
        /// <summary>
        /// Insert category with it's details to database
        /// </summary>
        /// <param name="entity">object of category </param>
        /// <returns>Object which inserted to database</returns>
        public override async Task<Category> AddEntityAsync(Category entity)
        {
            var category = GetAsQueryable(x => x.CategoryName == entity.CategoryName.Trim().ToUpper()&&!x.IsDelete).FirstOrDefault();
            if (category is not null)
            {
                if (entity.Items.Count > 0)
                    await ItemRepo.AddListEntities(entity.Items, category.CategoryId);
            }
            else
            {
                entity.CategoryId = CreateId<Category>(x => x.CategoryId);
                entity.CategoryName = entity.CategoryName.Trim().ToUpper();
                var items = entity.Items;
                entity.Items = default;
                await _operationHelper.InsertIntoDbAsync(entity);
                if (items.Count > 0)
                    await ItemRepo.AddListEntities(items, entity.CategoryId);
            }
            return entity;
        }
        /// <summary>
        /// Delete  category with details from database
        /// </summary>
        /// <param name="id"> id of categoury object </param>
        /// <returns> boolean as asunchronous</returns>
        public override async Task<bool> DeleteEntityAsync(int id)
        {
            var category = await GetByIdAsync(id);
            category.IsDelete = true;
            foreach (var item in category.Items.Where(x=>!x.IsDelete))
            {
                if (!item.IsDelete)
                    await ItemRepo.DeleteEntityAsync(item.ItemId);
            }
           return await _operationHelper.UpdateDbAsync(category);
        }
        /// <summary>
        /// Get all category details from database 
        /// </summary>
        /// <param name="filter"> expression func which take Type of category and return bool</param>
        /// <returns> category asqueryable </returns>
        public override IQueryable<Category> GetAll(Expression<Func<Category, bool>> filter)
        {
            var category = GetAsQueryable(filter);
            category.ForEachAsync(x => x.Store = StoreRepo.GetAsQueryable(s => s.StoreId == x.StoreId).FirstOrDefault());
            category.ForEachAsync(x => x.Items = ItemRepo.GetAsQueryable(i => i.CategoryId == x.CategoryId).ToList());
            return category;
        }
        /// <summary>
        /// Get object of category  depend on <paramref name="id"/> 
        /// </summary>
        /// <param name="id">id of category </param>
        /// <returns>object of category </returns>
        public override Task<Category> GetByIdAsync(int id) => GetAsQueryable(x => x.CategoryId == id).Include(x=>x.Items).FirstOrDefaultAsync();
        /// <summary>
        /// Upadate object of category in database
        /// </summary>
        /// <param name="entity"> object of category  to update </param>
        /// <returns>void method</returns>
        public override async Task<bool> UpdateEntityAsync(Category entity)
        {
            entity.CategoryName = entity.CategoryName.Trim().ToUpper();
             return await _operationHelper.UpdateDbAsync(entity);
        }
    }
}
