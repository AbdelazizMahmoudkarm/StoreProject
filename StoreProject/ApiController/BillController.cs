using Microsoft.EntityFrameworkCore;
using StoreProject.DAL;
using StoreProject.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StoreProject.ApiController
{
    [Route("api/[Controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly BillRepo _billRepo;
        public BillController(BillRepo billRepo)
            =>  _billRepo = billRepo;
        [HttpGet]
        public async Task<IActionResult> Get(int pageNumber=1,int numberOfElemenys=10 ,bool isbuy = false)
        {
            var bills = _billRepo.GetAsQueryable(x => x.IsBuy == isbuy).Include(c => c.Customer).OrderByDescending(x => x.BillId);
            if (bills is null) {
                return NoContent();
            }
            decimal totalPagesNumber = bills.Count() / numberOfElemenys;
            var data = new { Bills = await PaginatedList<Bill>.CreateAsync(bills, pageNumber, numberOfElemenys), pageNumber = Math.Ceiling(totalPagesNumber > 0 ? totalPagesNumber : 1) };
            return Ok(data);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int id)
        {
            var bill = await _billRepo.GetByIdAsync(id);
            if (bill is null)
            {
                return NotFound();
            }
            return Ok(bill);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Bill bill)
        {
            if(!ModelState.IsValid)
            {
                return Bad();
            }
            bill.UserName = User.Identity.Name;
           var entity= await _billRepo.AddEntityAsync(bill);
            if (entity is null)
                return NotFound();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromQuery]int id,[FromBody]Bill bill)
        {
            if(!ModelState.IsValid)
            {
                return Bad();
            }
            if(id!=bill.BillId)
            {
                return Bad();
            }
          bool isOk= await _billRepo.UpdateEntityAsync(bill);
            return isOk? NoContent():BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int billid, bool ReturnBillItemToStore)
        {
            bool ok;
            if (ReturnBillItemToStore)
            {
                ok = await _billRepo.DeleteEntityAsync(billid);
            }
            else
            {
                ok = await _billRepo.DeleteAllBillContentWithoutRetreiveDataToStore(billid);
            }
            return ok ? Ok() : Bad();
        }

        private ActionResult Bad()
        {
             return BadRequest("Please Enter a valid Data");
        }
    }

}
