using StoreProject.Models;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace StoreProject.DAL.ReposatoryClasess
{

    /// <summary>
    /// Use to manipulate date which use to define the store it self
    /// </summary>
    public class BrandImageRepo:BaseEntity<BrandImage>
    {
        private readonly OperationHelper _operationHelper;
        /// <summary>
        /// The constarctor which use denpendancy injection to define the objects which this class will use 
        /// </summary>
        /// <param name="operationHelper"> use to deal with database</param>
        public BrandImageRepo(OperationHelper operationHelper) : base(operationHelper) => _operationHelper = operationHelper;
        /// <summary>
        /// Get brand details entity as queryable using filter <paramref name="filter"/>
        /// </summary>
        /// <param name="filter">expression func which take Type of brand image class and return bool</param>
        /// <returns>Brand iamge entity as queryable</returns>
        public override IQueryable<BrandImage> GetAsQueryable(Expression<Func<BrandImage, bool>> filter)
            => CheckNull(filter);
        /// <summary>
        /// Insert Barnd detail to database
        /// </summary>
        /// <param name="entity">object of barnd image </param>
        /// <returns>Object of barnd image</returns>
        public override async Task<BrandImage> AddEntityAsync(BrandImage entity)
        {
            entity.Id = CreateId<BrandImage>(x=>x.Id);
            await _operationHelper.InsertIntoDbAsync(entity);
            return entity;
        }
        /// <summary>
        /// Delete the brand detail from database
        /// </summary>
        /// <param name="id"> id of brand image</param>
        /// <returns> boolean as asunchronous</returns>
        public override async Task<bool> DeleteEntityAsync(int id) => await _operationHelper.DeleteAsync(await GetByIdAsync(id));
        /// <summary>
        /// Get all brand image details from database 
        /// </summary>
        /// <param name="filter"> expression func which take Type of barnd image and return bool</param>
        /// <returns> barnd iamge asqueryable </returns>
        public override IQueryable<BrandImage> GetAll(Expression<Func<BrandImage, bool>> filter) => GetAsQueryable(filter);
        /// <summary>
        /// Get object of barnd image depend on <paramref name="id"/> 
        /// </summary>
        /// <param name="id">id of brand image</param>
        /// <returns>object of brand image</returns>
        public override async Task<BrandImage> GetByIdAsync(int id) => await GetAsQueryable(x => x.Id == id).FirstOrDefaultAsync();
        /// <summary>
        /// Upadate object of barnd image in database
        /// </summary>
        /// <param name="entity"> object of barnd image to update </param>
        /// <returns>void method</returns>
        public override async Task UpdateEntityAsync(BrandImage entity) => await _operationHelper.UpdateDbAsync(entity);
        /// <summary>
        /// Insert List of barnd image to database
        /// </summary>
        /// <param name="entities">list of barnd image</param>
        /// <param name="entityId">the foreignkey of barnd </param>
        /// <returns> void method</returns>
        public override async Task AddListEntities(List<BrandImage> entities, int entityId)
        {
            foreach (var entity in entities)
            {
                entity.BrandId = entityId;
                await AddEntityAsync(entity);
            }
        }
    }
}
