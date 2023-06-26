using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace StoreProject.DAL
{
    /// <summary>
    /// Pipe which use to supply computed number or raws to page 
    /// </summary>
    /// <typeparam name="T">generic type of eneity class</typeparam>
    public class PaginatedList<T> : List<T>
    {
        /// <summary>
        /// Number of page
        /// </summary>
        public int PageIndex { get; private set; }
        /// <summary>
        /// number of pages
        /// </summary>
        public int TotalPages { get; private set; }
        /// <summary>
        /// Constractor which use to define data which use
        /// </summary>
        /// <param name="items">list of enetity </param>
        /// <param name="count"> the count of data</param>
        /// <param name="pageIndex"> the number of page</param>
        /// <param name="pageSize"> the size of data in page</param>
        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }
        /// <summary>
        /// boolean property which return true if there is previous page else false
        /// </summary>
        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }
        /// <summary>
        /// boolean property which return true if there is next page else false
        /// </summary>
        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }
        /// <summary>
        /// Use to Create paginatedList 
        /// </summary>
        /// <param name="source"> the data type of class as Queryable</param>
        /// <param name="pageIndex"> the number of page </param>
        /// <param name="pageSize"> the number of data in this  page </param>
        /// <returns></returns>
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
       
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}