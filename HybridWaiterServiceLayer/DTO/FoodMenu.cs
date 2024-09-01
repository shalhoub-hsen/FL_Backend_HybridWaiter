using HybridWaiterDataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridWaiterServiceLayer.DTO
{
    public class FoodMenu : BaseDTO<FOODMENU>
    {
        [StringLength(255)]
        public string? Icon { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
        public int? ParentId { get; set; }

        [StringLength(255)]
        public string? Name { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal? Price { get; set; }

        [StringLength(255)]
        public string? ImageURL { get; set; }
        public bool? IsOutOfStock { get; set; }
    }
}

namespace HybridWaiterServiceLayer.Mapper
{
    using AutoMapper;
    public class AutoMapperFoodMenu : Profile
    {
        public AutoMapperFoodMenu()
        {
            CreateMap<DTO.FoodMenu, FOODMENU>().ReverseMap();

        }
    }
}

