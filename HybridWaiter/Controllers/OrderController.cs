using HybridWaiterDataLayer.Models;
using HybridWaiterServiceLayer.DTO;
using HybridWaiterServiceLayer.Services;
using HybridWaiterServiceLayer.UIModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HybridWaiterAPI.Controllers
{
    [Route("Order")]
    [ApiController,Authorize]
    public class OrderController : BaseController<ORDER, Order>
    {
        IOrderService service;
        public OrderController(IOrderService orderService) : base(orderService)
        {
            service = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderView order)
        {
            await service.PlaceOrder(UserID, order);
            return Ok(true);
        }
    }
}
