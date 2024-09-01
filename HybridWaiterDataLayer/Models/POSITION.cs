using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridWaiterDataLayer.Models
{
    public class POSITION : BASEENTITY
    {
        [StringLength(255)]
        public string? Values { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
        public ICollection<TEAMMEMBER>? TeamMembers { get; set; }
    }
}
