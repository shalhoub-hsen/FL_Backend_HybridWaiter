using HybridWaiterDataLayer.Models;

namespace HybridWaiterServiceLayer.DTO
{
    public class Bank : BaseDTO<BANK>
    {
        public long? Code { get; set; }
        public decimal? Amount { get; set; }
    }
}

namespace HybridWaiterServiceLayer.Mapper
{
    using AutoMapper;
    public class AutoMapperBank : Profile
    {
        public AutoMapperBank()
        {
            CreateMap<DTO.Bank, BANK>().ReverseMap();

        }
    }
}
