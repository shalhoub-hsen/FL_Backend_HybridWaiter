using HybridWaiterDataLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace HybridWaiterServiceLayer.DTO
{
    public class Booking : BaseDTO<BOOKING>
    {
        [StringLength(255)]
        public string? FullName { get; set; }

        [StringLength(255)]
        public string? Email { get; set; }
        public DateTime? Date { get; set; }

        public int? PeopleCount { get; set; }

        [StringLength(4000)]
        public string? SpecialRequest { get; set; }
    }
}

namespace HybridWaiterServiceLayer.Mapper
{
    using AutoMapper;
    public class AutoMapperBooking : Profile
    {
        public AutoMapperBooking()
        {
            CreateMap<DTO.Booking, BOOKING>().ReverseMap();

        }
    }
}

