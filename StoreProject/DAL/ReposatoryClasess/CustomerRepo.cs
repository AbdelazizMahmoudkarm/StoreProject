using Microsoft.EntityFrameworkCore;
using StoreProject.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace StoreProject.DAL.ReposatoryClasess
{
    /// <summary>
    /// Define the customer detail
    /// </summary>
    public class CustomerRepo : BaseEntity<Customer>
    {
        private readonly OperationHelper _operationHelper;

        /// <summary>
        /// Contractor which use to define the objects with use 
        /// </summary>
        /// <param name="operationHelper"></param>
        public CustomerRepo(OperationHelper operationHelper):base(operationHelper) => _operationHelper = operationHelper;
        /// <summary>
        /// Get customer entity as queryable using filter <paramref name="filter"/>
        /// </summary>
        /// <param name="filter">expression func which take Type of customer class and return bool</param>
        /// <returns>customer entity as queryable</returns>
        public override IQueryable<Customer> GetAsQueryable(Expression<Func<Customer, bool>> filter)
        => CheckNull(filter);
        /// <summary>
        /// Insert customer to database
        /// </summary>
        /// <param name="entity">object of customer</param>
        /// <returns>Object which inserted to database</returns>
        public override async Task<Customer> AddEntityAsync(Customer entity)
        {
            entity.CustomerId = CreateId<Customer>(x=>x.CustomerId);
           await _operationHelper.InsertIntoDbAsync(entity);
            return entity;
        }
        /// <summary>
        /// Delete customer with details from database
        /// </summary>
        /// <param name="id"> id of customer object</param>
        /// <returns> boolean as asunchronous</returns>
        public override async Task<bool> DeleteEntityAsync(int id) =>await _operationHelper.DeleteAsync(await GetByIdAsync(id));
        /// <summary>
        /// Get all customer  details from database 
        /// </summary>
        /// <param name="filter"> expression func which take Type of customer  and return bool</param>
        /// <returns> customer asqueryable </returns>
        public override IQueryable<Customer> GetAll(Expression<Func<Customer, bool>> filter) =>GetAsQueryable(filter);
        /// <summary>
        /// Get object of customer  depend on <paramref name="id"/> 
        /// </summary>
        /// <param name="id">id of customer </param>
        /// <returns>object of color </returns>
        public override async Task<Customer> GetByIdAsync(int id) => await GetAsQueryable(x => x.CustomerId == id).FirstOrDefaultAsync();
        /// <summary>
        /// Upadate object of customer in database
        /// </summary>
        /// <param name="entity"> object of color to update </param>
        /// <returns>void method</returns>
        public override async Task UpdateEntityAsync(Customer entity) => await _operationHelper.UpdateDbAsync(entity);
    }
}
