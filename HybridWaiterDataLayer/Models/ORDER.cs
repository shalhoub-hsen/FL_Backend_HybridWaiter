using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HybridWaiterDataLayer.Models
{
    public class ORDER : BASEENTITY
    {
        public int ClientId { get; set; }
        public int OrderTypeId { get; set; }
        public int OrderStatusId { get; set; }

        public string Address { get; set; }
        public string OrderName { get; set; }
        public string PhoneNumber { get; set; }
        public string Notes { get; set; }

        [ForeignKey("ClientId")]
        public CLIENT Client { get; set; }

        [ForeignKey("OrderTypeId")]
        public LOOKUP_VALUE OrderType { get; set; }
        [ForeignKey("OrderStatusId")]
        public LOOKUP_VALUE OrderStatus { get; set; }

        public IEnumerable<ORDER_DETAIL>? OrderDetails { get; set; }
    }
}

