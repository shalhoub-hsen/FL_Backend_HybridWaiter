using HybridWaiterDataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridWaiterServiceLayer.DTO
{
    public class ServiceList : BaseDTO<SERVICELIST>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
    }
}

namespace HybridWaiterServiceLayer.Mapper
{
    using AutoMapper;
    public class AutoMapperServiceList : Profile
    {
        public AutoMapperServiceList()
        {
            CreateMap<DTO.ServiceList, SERVICELIST>().ReverseMap();

        }
    }
}
