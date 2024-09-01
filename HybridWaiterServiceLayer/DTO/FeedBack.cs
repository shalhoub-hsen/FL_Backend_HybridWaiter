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
    public class FeedBack : BaseDTO<FEEDBACK>
    {
        public int ClientId { get; set; }
        public string? Quotient { get; set; }
        public string? Description { get; set; }
        public Client Client { get; set; }
    }
}

namespace HybridWaiterServiceLayer.Mapper
{
    using AutoMapper;
    public class AutoMapperFeedBack : Profile
    {
        public AutoMapperFeedBack()
        {
            CreateMap<DTO.FeedBack, FEEDBACK>().ReverseMap();

        }
    }
}
