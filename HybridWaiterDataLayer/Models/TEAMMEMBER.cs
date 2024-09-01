using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridWaiterDataLayer.Models
{
    public class TEAMMEMBER : BASEENTITY
    {
        [StringLength(255)]
        public string? ImageURL { get; set; }

        [StringLength(255)]
        public string? FirstName { get; set; }
        [StringLength(255)]
        public string? MiddleName { get; set; }
        [StringLength(255)]
        public string? LastName { get; set; }

        [Column(TypeName = "datetime2(6)")]
        public DateTime? DOB { get; set; }

        public int? PositionId { get; set; }


        [Column(TypeName = "datetime2(6)")]
        public DateTime? JoiningDate { get; set; }

        public bool? IsStill { get; set; }

        /* Foreign Keys */

        [ForeignKey("PositionId")]
        public POSITION Position { get; set; }
    }
}
