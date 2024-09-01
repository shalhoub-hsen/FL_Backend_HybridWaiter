using System.ComponentModel.DataAnnotations.Schema;

namespace HybridWaiterDataLayer.Models
{
    public class ORDER_DETAIL : BASEENTITY
    {
        public int OrderId { get; set; }
        public int FoodMenuId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        [ForeignKey("OrderId")]
        public ORDER Order { get; set; }

        [ForeignKey("FoodMenuId")]
        public FOODMENU FoodMenu { get; set; }
    }
}
