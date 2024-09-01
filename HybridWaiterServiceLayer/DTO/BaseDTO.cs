using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HybridWaiterDataLayer.Models;

namespace HybridWaiterServiceLayer.DTO
{
    public abstract class BaseDTO
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }

    /// <summary>
    /// This is the base DTO class, from which all DTOs should inherit.
    /// </summary>
    /// <remarks>
    /// This variant specifies a <typeparamref name="TDatabaseModel"/> database model from which the DTO SHOULD be directly convertable.
    /// <br/>
    /// Conversion from a <see cref="BaseDTO{TDatabaseModel}"/> back into a <typeparamref name="TDatabaseModel"/> is not guaranteed as some information may be lost during the initial transformation from database model to DTO.
    /// </remarks>
    /// 
    public abstract class BaseDTO<TDatabaseModel> where TDatabaseModel : BASEENTITY
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
}
