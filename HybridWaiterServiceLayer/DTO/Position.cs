using HybridWaiterDataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridWaiterServiceLayer.DTO
{
    public class Position : BaseDTO<POSITION>
    {
        public string? Values { get; set; }
        public string? Description { get; set; }
        public ICollection<TEAMMEMBER>? TeamMembers { get; set; }
    }
}

namespace HybridWaiterServiceLayer.Mapper
{
    using AutoMapper;
    public class AutoMapperPosition : Profile
    {
        public AutoMapperPosition()
        {
            CreateMap<DTO.Position, POSITION>().ReverseMap();

        }
    }
}
