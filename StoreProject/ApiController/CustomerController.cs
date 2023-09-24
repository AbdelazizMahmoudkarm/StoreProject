using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using StoreProject.DAL;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreProject.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class CustomerController : ControllerBase
    {

        private readonly BillRepo _billRepo;
        public CustomerController(BillRepo billRepo) => _billRepo = billRepo;
        [HttpGet]
        public async Task<IActionResult> Get(bool isbuy = false)
        {
            var bills = _billRepo.GetAsQueryable(x => x.IsBuy == isbuy).Include(c => c.Customer).ToList().DistinctBy(x => x.CustomerId);
            if (bills.Any())
            {
                foreach (var bill in bills)
                {
                    bill.Dept = await _billRepo.GetTotalNetAsync(x => x.CustomerId == bill.CustomerId);
                    bill.Pay = await _billRepo.PaidAsync(x => x.CustomerId == bill.CustomerId);
                }
               return Ok(bills);
            }
            return NoContent(); ;
        }
    }
}
