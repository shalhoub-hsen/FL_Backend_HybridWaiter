using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace HybridWaiterDataLayer.Models
{
    public class CLIENT: BASEENTITY
    {
        [StringLength(255)]
        public string? FirstName { get; set; }
        [StringLength(255)]
        public string? MiddleName { get; set; }
        [StringLength(255)]
        public string? LastName { get; set; }
        [StringLength(255)]
        public string? Email { get; set; }
        [StringLength(255)]
        public string? Password { get; set; }
        public bool? IsActive { get; set; }

        [StringLength(255)]
        public string? VerificationCode { get; set; }

        [Column(TypeName = "datetime2(6)")]
        public DateTime? VerificationCodeExpiryDate { get; set; }

        public ICollection<FEEDBACK>? Feedbacks { get; set; }
    }
}
