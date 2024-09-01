using System.ComponentModel.DataAnnotations;

namespace HybridWaiterDataLayer.Models
{
    public class BOOKING : BASEENTITY
    {
        [StringLength(255)]
        public string? FullName { get; set; }

        [StringLength(255)]
        public string? Email{ get; set; }
        public DateTime? Date{ get; set; }

        public int? PeopleCount { get; set; }

        [StringLength(4000)]
        public string? SpecialRequest { get; set; }

    }
}
