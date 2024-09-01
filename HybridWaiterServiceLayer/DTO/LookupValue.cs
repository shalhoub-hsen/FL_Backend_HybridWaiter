using HybridWaiterDataLayer.Models;

namespace HybridWaiterServiceLayer.DTO
{
    public class LookupValue : BaseDTO<LOOKUP_VALUE>
    {
        public string Value { get; set; }
        public string? Description { get; set; }
        public int? ParentId { get; set; }
        public string Code { get; set; }

    }
}


namespace HybridWaiterServiceLayer.Mapper
{
    using AutoMapper;
    public class AutoMapperLookupValue : Profile
    {
        public AutoMapperLookupValue()
        {
            CreateMap<DTO.LookupValue, LOOKUP_VALUE>().ReverseMap();

        }
    }
}
