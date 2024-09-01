using HybridWaiterDataLayer.Models;
using HybridWaiterServiceLayer.DTO;
using HybridWaiterServiceLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace HybridWaiterAPI.Controllers
{
    [ApiController]
    [Route("FoodMenu")]
    public class FoodMenuController : BaseController<FOODMENU, FoodMenu>
    {
        IFoodMenuService service;
        public FoodMenuController(IFoodMenuService foodMenuService) : base(foodMenuService)
        {
            service = foodMenuService;
        }

        [HttpGet("GetCategories")]
        public async Task<ActionResult> GetCategories()
        {
            IEnumerable<FoodMenu> menu = await service.GetCategories();
            return Ok(menu);
        }
        [HttpGet("GetMenuTable")]
        public async Task<IEnumerable<object>> GetMenuTable()
        {
            var menu = await service.GetMenuTable();
            return menu;
        }
    }
}
