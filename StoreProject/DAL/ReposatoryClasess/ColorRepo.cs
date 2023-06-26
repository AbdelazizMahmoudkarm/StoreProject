using Microsoft.EntityFrameworkCore;
using StoreProject.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StoreProject.DAL
{
    /// <summary>
    /// define the color of program
    /// </summary>
    public class ColorRepo:BaseEntity<Color>
    {
        private readonly OperationHelper _operationHelper;
        /// <summary>
        /// Contractor which use to define the objects with use 
        /// </summary>
        /// <param name="operationHelper">deal with database</param>
        public ColorRepo(OperationHelper operationHelper):base(operationHelper) => this._operationHelper = operationHelper;
        /// <summary>
        /// Get color  entity as queryable using filter <paramref name="filter"/>
        /// </summary>
        /// <param name="filter">expression func which take Type of color class and return bool</param>
        /// <returns>color entity as queryable</returns>
        public override IQueryable<Color> GetAsQueryable(Expression<Func<Color, bool>> filter =default) =>
           CheckNull(filter);
        /// <summary>
        /// Insert color to database
        /// </summary>
        /// <param name="entity">object of color</param>
        /// <returns>Object which inserted to database</returns>
        public override async Task<Color> AddEntityAsync(Color entity)
        {
            entity.ColorId = CreateId<Color>(x=>x.ColorId);
            await _operationHelper.InsertIntoDbAsync(entity);
            return entity;
        }
        /// <summary>
        /// Delete  color from database
        /// </summary>
        /// <param name="id"> id of color object</param>
        /// <returns> boolean as asunchronous</returns>
        public override async Task<bool> DeleteEntityAsync(int id)
        {
            var  color = GetByIdAsync(id).Result;
            color.IsDelete = true;
           return await _operationHelper.UpdateDbAsync(color);
        }
        /// <summary>
        /// Get all colors from database 
        /// </summary>
        /// <param name="filter"> expression func which take Type of color  and return bool</param>
        /// <returns> color asqueryable </returns>
        public override IQueryable<Color> GetAll(Expression<Func<Color, bool>> filter) => GetAsQueryable(filter);
        /// <summary>
        /// Get object of color  depend on <paramref name="id"/> 
        /// </summary>
        /// <param name="id">id of color </param>
        /// <returns>object of color </returns>
        public override async Task<Color> GetByIdAsync(int id) => await GetAsQueryable(x => x.ColorId == id).FirstOrDefaultAsync();
        /// <summary>
        /// Upadate object of color in database
        /// </summary>
        /// <param name="entity"> object of color to update </param>
        /// <returns>void method</returns>
        public override async Task UpdateEntityAsync(Color entity) => await _operationHelper.UpdateDbAsync(entity);
    }
}
