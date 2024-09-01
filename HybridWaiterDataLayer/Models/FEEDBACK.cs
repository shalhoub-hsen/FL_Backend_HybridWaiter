using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridWaiterDataLayer.Models
{
    public class FEEDBACK : BASEENTITY
    {
        public int ClientId { get; set; }
        [StringLength(250)]
        public string? Quotient { get; set; }
        [StringLength(250)]
        public string? Description { get; set; }
        [ForeignKey("ClientId")]
        public CLIENT Client { get; set; }
    }
}
