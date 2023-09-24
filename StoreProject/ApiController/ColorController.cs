using System.Threading.Tasks;
using StoreProject.DAL;
using StoreProject.Models;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace StoreProject.ApiController
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ColorController : ControllerBase
    {
        private readonly ColorRepo _colorRepo;

        public ColorController(ColorRepo colorrepo) => _colorRepo = colorrepo;
        [HttpGet]
        public async Task<IActionResult> Get(int pageNumber,int numberOfElements)
        {
            var colors = _colorRepo.GetAll(x => x.IsDelete == false);
            if (colors is null)
            {
                return NoContent();
            }
            decimal totalPagesNumber = colors.Count() / numberOfElements;
            var data = new { Bills = await PaginatedList<Color>.CreateAsync(colors, pageNumber, numberOfElements), pageNumber = Math.Ceiling(totalPagesNumber > 0 ? totalPagesNumber : 1) };
            return Ok(colors);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var data = _colorRepo.GetByIdAsync(id);
            if(data is null)
            {
                return BadRequest();
            }
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Color color)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please Fill the form");
            }
            var data = await _colorRepo.AddEntityAsync(color);
            if (data is null)
            {
                return BadRequest();
            }
            return NoContent();

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromQuery]int id,Color color)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please Fill the form");
            }
            if (id != color.ColorId)
            {
                return BadRequest();
            }
           await _colorRepo.UpdateEntityAsync(color);
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if(id==0)
            {
                return BadRequest();
            }
           bool isOk= await _colorRepo.DeleteEntityAsync(id);
            return isOk ? NoContent() : BadRequest();
        }
    }
}
