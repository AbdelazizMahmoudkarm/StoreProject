using Microsoft.EntityFrameworkCore;
using StoreProject.DAL;
using System.Linq;
using System.Threading.Tasks;

namespace StoreProject.Controllers
{
    public class CustomersController : Controller
    {
        private readonly BillRepo _billRepo;
        public CustomersController(BillRepo billRepo) => _billRepo = billRepo;
        public IActionResult Index() => View();
        public async Task<IActionResult> Customer(bool isbuy = false)
        {
            var bills = _billRepo.GetAsQueryable(x => x.IsBuy == isbuy).Include(c => c.Customer).ToList().DistinctBy(x=>x.CustomerId);
            if (bills.Any())
            {
                foreach (var bill in bills)
                { 
                    bill.Dept = await _billRepo.GetTotalNetAsync(x=>x.CustomerId==bill.CustomerId);
                    bill.Pay = await _billRepo.PaidAsync(x => x.CustomerId == bill.CustomerId);
                    return PartialView(bills);
                }
            }
            return PartialView();
        }
    }
}
