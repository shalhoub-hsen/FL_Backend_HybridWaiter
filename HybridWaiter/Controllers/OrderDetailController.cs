using HybridWaiterDataLayer.Models;
using HybridWaiterServiceLayer.DTO;
using HybridWaiterServiceLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace HybridWaiterAPI.Controllers
{
    [ApiController]
    [Route("OrderDetail")]
    public class OrderDetailController : BaseController<ORDER_DETAIL, OrderDetail>
    {
        IOrderDetailService service;
        public OrderDetailController(IOrderDetailService orderDetailService) : base(orderDetailService)
        {
            service = orderDetailService;
        }
    }
}
