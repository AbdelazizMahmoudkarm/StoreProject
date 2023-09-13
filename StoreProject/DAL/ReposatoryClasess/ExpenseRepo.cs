using Microsoft.EntityFrameworkCore;
using StoreProject.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StoreProject.DAL
{
    /// <summary>
    /// Represnt the money which spends in the store
    /// </summary>
    public class ExpenseRepo : BaseEntity<Expense>
    {
        private readonly OperationHelper _operationHelper;
        /// <summary>
        /// Contractor which use to define the objects with use 
        /// </summary>
        /// <param name="operationHelper"></param>
        public ExpenseRepo(OperationHelper operationHelper) : base(operationHelper) => _operationHelper = operationHelper;
        /// <summary>
        /// Get entity as queryable using filter <paramref name="filter"/>
        /// </summary>
        /// <param name="filter">expression func which take Type of expense class and return bool</param>
        /// <returns> entity as queryable</returns>
        public override IQueryable<Expense> GetAsQueryable(Expression<Func<Expense, bool>> filter = null) =>
           CheckNull(filter);
        /// <summary>
        /// Insert enity to database
        /// </summary>
        /// <param name="entity">object of expense</param>
        /// <returns>Object which inserted to database</returns>
        public override async Task<Expense> AddEntityAsync(Expense entity)
        {
            await _operationHelper.InsertIntoDbAsync(entity);
            return entity;
        }
        /// <summary>
        /// Delete entity from database
        /// </summary>
        /// <param name="id"> id expense object</param>
        /// <returns> boolean as asunchronous</returns>
        public override async Task<bool> DeleteEntityAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            return await _operationHelper.DeleteAsync(entity);
        }
        /// <summary>
        /// Get all expense from database depend on filter<paramref name="filter"/>
        /// </summary>
        /// <param name="filter"> expression func which take Type of expense  and return bool</param>
        /// <returns> expense asqueryable </returns>
        public override IQueryable<Expense> GetAll(Expression<Func<Expense, bool>> filter) => GetAsQueryable(filter);
        /// <summary>
        /// Get object of enity depend on <paramref name="id"/> 
        /// </summary>
        /// <param name="id">id of expense </param>
        /// <returns>object of expense </returns>
        public override async Task<Expense> GetByIdAsync(int id) => await GetAsQueryable(x => x.Id == id).FirstOrDefaultAsync();
        /// <summary>
        /// Upadate object of enity in database
        /// </summary>
        /// <param name="entity"> object of expense </param>
        /// <returns>void method</returns>
        public override async Task UpdateEntityAsync(Expense entity) => await _operationHelper.UpdateDbAsync(entity);
    }
}
