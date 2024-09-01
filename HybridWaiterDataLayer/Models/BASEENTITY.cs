using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridWaiterDataLayer.Models
{
    public abstract class BASEENTITY
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "datetime2(6)")]
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
