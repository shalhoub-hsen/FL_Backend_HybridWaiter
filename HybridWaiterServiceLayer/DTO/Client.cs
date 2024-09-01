using HybridWaiterDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridWaiterServiceLayer.DTO
{
    public class Client : BaseDTO<CLIENT>
    {
        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }
        public bool? IsActive { get; set; }
        public string? VerificationCode { get; set; }

        public DateTime? VerificationCodeExpiryDate { get; set; }

        public ICollection<FeedBack>? Feedbacks { get; set; }
    }
}
/////////////////////////////////////////////////////////////////////
namespace HybridWaiterServiceLayer.Mapper
{
    using AutoMapper;
    public class AutoMapperClient : Profile
    {
        public AutoMapperClient()
        {
            CreateMap<DTO.Client, CLIENT>().ReverseMap();

        }
    }
}
