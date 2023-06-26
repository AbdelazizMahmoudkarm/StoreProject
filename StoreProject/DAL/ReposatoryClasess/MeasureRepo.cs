using Microsoft.EntityFrameworkCore;
using StoreProject.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StoreProject.DAL
{

    /// <summary>
    /// define the measure of program
    /// </summary>
    public class MeasureRepo:BaseEntity<Measure>
    {
        private readonly OperationHelper _operationHelper;
        /// <summary>
        /// Contractor which use to define the objects with use 
        /// </summary>
        /// <param name="operationHelper">deal with database</param>
        public MeasureRepo(OperationHelper operationHelper):base(operationHelper) => _operationHelper = operationHelper;
        /// <summary>
        /// Get measure  entity as queryable using filter <paramref name="filter"/>
        /// </summary>
        /// <param name="filter">expression func which take Type of measure class and return bool</param>
        /// <returns>measure entity as queryable</returns>
        public override IQueryable<Measure> GetAsQueryable(Expression<Func<Measure, bool>> filter=default) =>
           CheckNull(filter);
        /// <summary>
        /// Insert measure to database
        /// </summary>
        /// <param name="entity">object of measure</param>
        /// <returns>Object which inserted to database</returns>
        public override async Task<Measure> AddEntityAsync(Measure entity)
        {
            entity.MeasureId = CreateId<Measure>(x=>x.MeasureId);
            await _operationHelper.InsertIntoDbAsync(entity);
            return entity;
        }
        /// <summary>
        /// Delete  measure from database
        /// </summary>
        /// <param name="id"> id of mesaure object</param>
        /// <returns> boolean as asunchronous</returns>
        public override async Task<bool> DeleteEntityAsync(int id)
        {
            var measure = await GetByIdAsync(id);
            measure.IsDelete = true;
            return await _operationHelper.UpdateDbAsync(measure);
        }
        /// <summary>
        /// Get all measures from database 
        /// </summary>
        /// <param name="filter"> expression func which take Type of measure  and return bool</param>
        /// <returns> measure asqueryable </returns>
        public override IQueryable<Measure> GetAll(Expression<Func<Measure, bool>> filter) => GetAsQueryable(filter);
        /// <summary>
        /// Get object of measure  depend on <paramref name="id"/> 
        /// </summary>
        /// <param name="id">id of measure </param>
        /// <returns>object of measure </returns>
        public override async Task<Measure> GetByIdAsync(int id) => await GetAsQueryable(x=>x.MeasureId==id).FirstOrDefaultAsync();
        /// <summary>
        /// Upadate object of measure in database
        /// </summary>
        /// <param name="entity"> object of measure to update </param>
        /// <returns>void method</returns>
        public override async Task UpdateEntityAsync(Measure entity) => await _operationHelper.UpdateDbAsync(entity);
    }
}
