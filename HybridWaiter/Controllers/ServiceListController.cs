using HybridWaiterDataLayer.Models;
using HybridWaiterServiceLayer.DTO;
using HybridWaiterServiceLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HybridWaiterAPI.Controllers
{
    [ApiController]
    [Route("ServiceList")]
    public class ServiceListController : BaseController<SERVICELIST, ServiceList>
    {
        IServiceListService service;
        public ServiceListController(IServiceListService serviceListService) : base(serviceListService)
        {
            service = serviceListService;
        }
    }
}
