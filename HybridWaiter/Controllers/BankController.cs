using HybridWaiterDataLayer.Models;
using HybridWaiterServiceLayer.DTO;
using HybridWaiterServiceLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace HybridWaiterAPI.Controllers
{
    [ApiController]
    [Route("Bank")]
    public class BankController : BaseController<BANK, Bank>
    {
        IBankService service;
        public BankController(IBankService bankService) : base(bankService)
        {
            service = bankService;
        }
    }
}
