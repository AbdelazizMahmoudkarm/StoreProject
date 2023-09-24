using StoreProject.DAL;
using StoreProject.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreProject.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly StoreRepo _storeRepo;
        public StoreController(StoreRepo storeRepo) => _storeRepo = storeRepo;
        // GET: api/<Store>
        [HttpGet]
        public async Task<IActionResult> Get(int pageNumber = 1, int numberOfElemenys = 10, bool isbuy = false)
        {
            var model = _storeRepo.GetAsQueryable(x => x.IsDelete == false);
            if(model is null)
            {
                return NoContent();
            }
            decimal totalPagesNumber = model.Count() / numberOfElemenys;
            var data = new { Stores = await PaginatedList<Store>.CreateAsync(model, pageNumber, numberOfElemenys), pageNumber = Math.Ceiling(totalPagesNumber > 0 ? totalPagesNumber : 1) };
            return Ok(data);
        }

        // GET api/<Store>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var store = await _storeRepo.GetByIdAsync(id);
            if(store is null)
            {
                return NotFound();
            }
            return Ok(store);
        }
        

        // POST api/<Store>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return BadRequest();
            }
            var store= await _storeRepo.AddEntityAsync(new Store { IsDelete = false, StoreName = value });
            if (store is null)
                return BadRequest();
            return NoContent();
        }

        // PUT api/<Store>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Store store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (id != store.StoreId)
            {
                return BadRequest();
            }
            await _storeRepo.UpdateEntityAsync(store);
            return NoContent();
        }

        // DELETE api/<Store>/5
        [HttpDelete("{id}")]
        public async Task< IActionResult> Delete(int id)
        {
            var isdel=await _storeRepo.DeleteEntityAsync(id);
           return  isdel? NoContent():BadRequest();
        }
    }
}
