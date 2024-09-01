using HybridWaiterDataLayer.Models;
using HybridWaiterServiceLayer.DTO;
using HybridWaiterServiceLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace HybridWaiterAPI.Controllers
{
    [ApiController]
    [Route("LookupValue")]
    public class LookupValueController : BaseController<LOOKUP_VALUE, LookupValue>
    {
        ILookupValueService service;
        public LookupValueController(ILookupValueService lookupValueService) : base(lookupValueService)
        {
            service = lookupValueService;
        }
    }
}
