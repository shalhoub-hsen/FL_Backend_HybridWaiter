

using HybridWaiterServiceLayer.DTO;

namespace HybridWaiterServiceLayer.UIModels
{
    public class OrderView
    {
        public string Address { get; set; }
        public string OrderName { get; set; }
        public string PhoneNumber { get; set; }
        public string Notes { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
