using Microsoft.EntityFrameworkCore;
using StoreProject.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StoreProject.DAL.ReposatoryClasess
{
    /// <summary>
    /// Has some information about the store which use this prgram
    /// </summary>
    public class BrandRepo : BaseEntity<Brand>
    {
        private readonly OperationHelper _operationHelper;
        private readonly BrandImageRepo _brandImageRepo;

        /// <summary>
        ///  The constarctor which use denpendancy injection to define the objects which this class will use 
        /// </summary>
        /// <param name="operationHelper"> use to deal with database</param>
        /// <param name="brandImageRepo"> define the details of brand</param>
        public BrandRepo(OperationHelper operationHelper, BrandImageRepo brandImageRepo) : base(operationHelper)
        {
            _operationHelper = operationHelper;
            _brandImageRepo = brandImageRepo;
        }
        /// <summary>
        /// Get brand  entity as queryable using filter <paramref name="filter"/>
        /// </summary>
        /// <param name="filter">expression func which take Type of brand class and return bool</param>
        /// <returns>Brand  entity as queryable</returns>
        public override IQueryable<Brand> GetAsQueryable(Expression<Func<Brand, bool>> filter=default)
            => CheckNull(filter);
        /// <summary>
        /// Insert Barnd with it's details to database
        /// </summary>
        /// <param name="entity">object of barnd  </param>
        /// <returns>Object which inserted to database</returns>
        public override async Task<Brand> AddEntityAsync(Brand entity)
        {
            entity.BrandId = CreateId<Brand>(x=>x.BrandId);
            var brandimages= entity.BrandImages;
            entity.BrandImages =default;
            await _operationHelper.InsertIntoDbAsync(entity);
            if (brandimages.Count > 0)
               await  _brandImageRepo.AddListEntities(brandimages, entity.BrandId);
            return entity;
        }
        /// <summary>
        /// Delete  brand with details from database
        /// </summary>
        /// <param name="id"> id of brand object</param>
        /// <returns> boolean as asunchronous</returns>
        public override async Task<bool> DeleteEntityAsync(int id) => await _operationHelper.DeleteAsync(await GetByIdAsync(id));

        /// <summary>
        /// Get all brand  details from database 
        /// </summary>
        /// <param name="filter"> expression func which take Type of barnd  and return bool</param>
        /// <returns> barnd asqueryable </returns>
        public override IQueryable<Brand> GetAll(Expression<Func<Brand, bool>> filter) => GetAsQueryable(filter);
        /// <summary>
        /// Get object of barnd  depend on <paramref name="id"/> 
        /// </summary>
        /// <param name="id">id of brand </param>
        /// <returns>object of brand </returns>
        public override async Task<Brand> GetByIdAsync(int id) => await GetAsQueryable(x => x.BrandId == id).FirstOrDefaultAsync();
        /// <summary>
        /// Upadate object of barnd in database
        /// </summary>
        /// <param name="entity"> object of barnd  to update </param>
        /// <returns>void method</returns>
        public override async Task UpdateEntityAsync(Brand entity)
        {
            foreach (var brand in entity.BrandImages)
                await _brandImageRepo.UpdateEntityAsync(brand);
            await _operationHelper.UpdateDbAsync(entity);
        }
    }
}
