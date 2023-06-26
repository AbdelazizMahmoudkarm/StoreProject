using Microsoft.EntityFrameworkCore;
using StoreProject.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StoreProject.DAL
{
    /// <summary>
    /// Represnt the store of program
    /// </summary>
    public class StoreRepo : BaseEntity<Store>
    {
        private readonly OperationHelper _operationHelper;
        /// <summary>
        /// Contractor which use to define the objects with use 
        /// </summary>
        /// <param name="operationHelper"></param>
        public StoreRepo(OperationHelper operationHelper) : base(operationHelper) => _operationHelper = operationHelper;
        /// <summary>
        /// Get entity as queryable using filter <paramref name="filter"/>
        /// </summary>
        /// <param name="filter">expression func which take Type of store class and return bool</param>
        /// <returns> entity as queryable</returns>
        public override IQueryable<Store> GetAsQueryable(Expression<Func<Store, bool>> filter =null) =>
           CheckNull(filter);
        /// <summary>
        /// Insert enity to database
        /// </summary>
        /// <param name="entity">object of store</param>
        /// <returns>Object which inserted to database</returns>
        public override async Task<Store> AddEntityAsync(Store entity)
        {
            entity.StoreId = CreateId<Store>(x=>x.StoreId);
            await _operationHelper.InsertIntoDbAsync(entity);
            return entity;
        }
        /// <summary>
        /// Delete entity from database
        /// </summary>
        /// <param name="id"> id store object</param>
        /// <returns> boolean as asunchronous</returns>
        public override async Task<bool> DeleteEntityAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            entity.IsDelete = true;
            return await _operationHelper.UpdateDbAsync(entity);
        }
        /// <summary>
        /// Get all store from database depend on filter<paramref name="filter"/>
        /// </summary>
        /// <param name="filter"> expression func which take Type of store  and return bool</param>
        /// <returns> store asqueryable </returns>
        public override IQueryable<Store> GetAll(Expression<Func<Store, bool>> filter) => GetAsQueryable(filter);
        /// <summary>
        /// Get object of enity  depend on <paramref name="id"/> 
        /// </summary>
        /// <param name="id">id of store </param>
        /// <returns>object of store </returns>
        public override async Task<Store> GetByIdAsync(int id) => await GetAsQueryable(x => x.StoreId == id).FirstOrDefaultAsync();
        /// <summary>
        /// Upadate object of enity in database
        /// </summary>
        /// <param name="entity"> object of store </param>
        /// <returns>void method</returns>
        public override async Task UpdateEntityAsync(Store entity) => await _operationHelper.UpdateDbAsync(entity);
    }
}
