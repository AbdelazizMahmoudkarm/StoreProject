using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreProject.DAL;
using StoreProject.Models;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;

namespace StoreProject.ApiController
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class MeasureController : ControllerBase
    {
        private readonly MeasureRepo _measurerepo;
        public MeasureController(MeasureRepo measurrepo) => _measurerepo = measurrepo;

        // GET: Measurements
        [HttpGet]
        public async Task<IActionResult> Get(int pageNumber,int numberOfElements)
        {
            var measures = _measurerepo.GetAll(x => x.IsDelete == false);
            if (measures is null)
            {
                return NoContent();
            }
            decimal totalPagesNumber = measures.Count() / numberOfElements;
            var data = new { Bills = await PaginatedList<Measure>.CreateAsync(measures, pageNumber, numberOfElements), pageNumber = Math.Ceiling(totalPagesNumber > 0 ? totalPagesNumber : 1) };
            return Ok(measures);
        }

        // GET: Measurements/Details/5

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id )
        {
            if (id == 0)
            {
                return NotFound();
            }
           var entity= await _measurerepo.GetByIdAsync(id);
            if(entity is null)
            {
                return BadRequest(); 
            }    
            return Ok(entity);

        }

        // POST: Measurements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Post([FromBody]Measure measure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();   
            }
           var data= await _measurerepo.AddEntityAsync(measure);
            if(data is null)
            {
                return BadRequest();
            }
            return NoContent();

        }

        // GET: Measurements/Edit/5
        [HttpPut]
        public async Task<IActionResult> Put([FromQuery] int id, [FromBody] Measure measure)
        {
            if (id == 0)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (id != measure.MeasureId)
            {
                return BadRequest(0);
            }
            var data = await _measurerepo.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        // POST: Measurements/Delete/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if(id==0)
            {
                return NotFound();
            }
          bool isok = await _measurerepo.DeleteEntityAsync(id);
            return isok? NoContent():BadRequest();
        }
    }
}
