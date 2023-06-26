using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StoreProject.DAL
{
    /// <summary>
    /// Genarally it resposible for dealing with database set or add or update or retrive or delete data to and from database
    /// </summary>
    public  class OperationHelper
    {
        /// <summary>
        /// Generate and connect to database which OperationHelper use to perform it's operations.
        /// </summary>
        public  readonly AppDb _dbcontext;
        /// <summary>
        /// Get the object of context from dependancy injection.
        /// </summary>
        /// <param name="context"> object of dbcontext to deal with database</param>
        public OperationHelper(AppDb context) => _dbcontext = context;
        /// <summary>
        /// Get  generic entity with expression of delegete with T and and return bool filter <paramref name="filter"/> 
        /// </summary>
        /// <typeparam name="T"> generic type of entity</typeparam>
        /// <param name="filter"> expression of delegete with T and and return bool </param>
        /// <returns> Generic entity as queryable </returns>
        public IQueryable<T> GetAny<T>(Expression<Func<T, bool>> filter) where T : class =>_dbcontext.Set<T>().Where(filter).AsQueryable();

        /// <summary>
        /// Get  generic entity without filter
        /// </summary>
        /// <typeparam name="T"> generic type of entity</typeparam>
        /// <returns> Generic entity as queryable </returns>
        public IQueryable<T> GetAnyWithoutCondition<T>() where T : class => _dbcontext.Set<T>().AsQueryable();

        /// <summary>
        /// Insert object type of generic entity as parameter
        /// </summary>
        /// <typeparam name="T"> Generic type of entity where T is type of Class</typeparam>
        /// <param name="entity"> object of entity</param>
        /// <returns> bool as asynchronous</returns>
        public async Task<bool> InsertIntoDbAsync<T>(T entity) where T : class
        {
            using (_dbcontext)
            {
                await _dbcontext.Set<T>().AddAsync(entity);
                await _dbcontext.SaveChangesAsync();
            }
            return true;
        }

        /// <summary>
        /// Update object type of generic entity as parameter
        /// </summary>
        /// <typeparam name="T"> Generic type of entity where T is type of Class</typeparam>
        /// <param name="entity"> object of entity</param>
        /// <returns> bool as asynchronous</returns>
        public async Task<bool> UpdateDbAsync<T>(T entity) where T : class
        {
            using (_dbcontext)
            {
                _dbcontext.Update(entity);
                await _dbcontext.SaveChangesAsync();
            }
            return true;
        }

        /// <summary>
        /// Delete object type of generic entity as parameter
        /// </summary>
        /// <typeparam name="T"> Generic type of entity where T is type of Class</typeparam>
        /// <param name="entity"> object of entity</param>
        /// <returns> bool as asynchronous</returns>
        public async Task<bool> DeleteAsync<T>(T entity) where T : class
        {
            using (_dbcontext)
            {
                _dbcontext.Remove(entity);
                await _dbcontext.SaveChangesAsync();
            }
            return true;
        }
    }
}
