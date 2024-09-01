using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HybridWaiterDataLayer.Models
{
    public class LOOKUP_VALUE : BASEENTITY
    {
        [StringLength(255)]
        public string Value { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }
        public int? ParentId { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        [ForeignKey("ParentId")]
        public LOOKUP_VALUE? Parent { get; set; }
    }
}
