using Microsoft.EntityFrameworkCore;
using StoreProject.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StoreProject.DAL.ReposatoryClasess
{
    /// <summary>
    /// Customer payment details
    /// </summary>
    public class PaymentRepo : BaseEntity<Payment>
    {
        private readonly OperationHelper _operationHelper;
        /// <summary>
        /// Contractor which use to define the objects with use 
        /// </summary>
        /// <param name="operationHelper"></param>
        public PaymentRepo(OperationHelper operationHelper):base(operationHelper) => _operationHelper = operationHelper;
        /// <summary>
        /// Get entity as queryable using filter <paramref name="filter"/>
        /// </summary>
        /// <param name="filter">expression func which take Type of payment class and return bool</param>
        /// <returns> entity as queryable</returns>
        public override IQueryable<Payment> GetAsQueryable(Expression<Func<Payment, bool>> filter) =>
          CheckNull(filter);
        /// <summary>
        /// Insert enity to database
        /// </summary>
        /// <param name="entity">object of payment</param>
        /// <returns>Object which inserted to database</returns>
        public override  async Task<Payment> AddEntityAsync(Payment entity)
        {
            entity.PaymentId = CreateId<Payment>(x => x.PaymentId);
            entity.Date = DateTimeNow();
            await  _operationHelper.InsertIntoDbAsync(entity);
            return entity;
        }
        /// <summary>
        /// Delete entity from database
        /// </summary>
        /// <param name="id"> id payment object</param>
        /// <returns> boolean as asunchronous</returns>
        public override async Task<bool> DeleteEntityAsync(int id) => await _operationHelper.DeleteAsync(await GetByIdAsync(id));
        /// <summary>
        /// Get all store from database depend on filter<paramref name="filter"/>
        /// </summary>
        /// <param name="filter"> expression func which take Type of payment  and return bool</param>
        /// <returns>payment asqueryable </returns>
        public override IQueryable<Payment> GetAll(Expression<Func<Payment, bool>> filter =null) => GetAsQueryable(filter);
        /// <summary>
        /// Get object of enity  depend on <paramref name="id"/> 
        /// </summary>
        /// <param name="id">id of payment </param>
        /// <returns>object of payment </returns>
        public override async Task<Payment> GetByIdAsync(int id) =>await GetAsQueryable(x=>x.PaymentId==id).FirstOrDefaultAsync();
        /// <summary>
        /// Upadate object of enity in database
        /// </summary>
        /// <param name="entity"> object of payment </param>
        /// <returns>void method</returns>
        public override async Task UpdateEntityAsync(Payment entity) =>await _operationHelper.UpdateDbAsync(entity);
    }
}
