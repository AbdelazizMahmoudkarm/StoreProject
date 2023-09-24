// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using StoreProject.DAL;
using StoreProject.DAL.ReposatoryClasess;
using StoreProject.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StoreProject.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class ItemController : ControllerBase
    {
        private readonly CategoryRepo _categoryRepo;
        public ItemController(CategoryRepo itemRepo) => _categoryRepo = itemRepo;

        // GET: api/<ItemController>
        [HttpGet]
        public async Task<IActionResult> Get(int pageNumber = 1, int numberOfElemenys = 10)
        {
            var items = _categoryRepo.GetAsQueryable(x => x.IsDelete == false).Include(x => x.Store);
            if(items is not null )
            {
                return NoContent();
            }
            decimal totalPagesNumber = items.Count() / numberOfElemenys;
            var data =new { items = await PaginatedList<Category>.CreateAsync(items, pageNumber, numberOfElemenys),pageNumber= Math.Ceiling(totalPagesNumber > 0 ? totalPagesNumber : 1) };
            return Ok(data);
        }

        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item=await _categoryRepo.GetByIdAsync(id);
            if(item is null )
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST api/<ItemController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category category)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var data = await _categoryRepo.AddEntityAsync(category);
            if(data is null)
            {
                return BadRequest();
            }
            return NoContent();
        }

        // PUT api/<ItemController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if(id!=category.CategoryId)
            {
                return BadRequest();
            }
         bool isOk=  await _categoryRepo.UpdateEntityAsync(category);
            return isOk ? NoContent() : BadRequest();
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool isOk =await _categoryRepo.DeleteEntityAsync(id);
            return isOk ? NoContent() : BadRequest();
        }
    }
}
