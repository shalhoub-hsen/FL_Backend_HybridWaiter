using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridWaiterDataLayer.Models
{
    public class SERVICELIST : BASEENTITY
    {
        [StringLength(255)]
        public string? Name { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
        [StringLength(100)]
        public string? Icon { get; set; }
    }
}
