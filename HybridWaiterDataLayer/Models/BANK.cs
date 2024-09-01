using System.ComponentModel.DataAnnotations;

namespace HybridWaiterDataLayer.Models
{
    public class BANK : BASEENTITY
    {
        public long? Code { get; set; }
        public decimal? Amount { get; set; }
    }
}
