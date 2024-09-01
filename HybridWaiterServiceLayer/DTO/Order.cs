using HybridWaiterDataLayer.Models;

namespace HybridWaiterServiceLayer.DTO
{
    public class Order : BaseDTO<ORDER>
    {
        public int ClientId { get; set; }
        public int OrderTypeId { get; set; }
        public int OrderStatusId { get; set; }
        public string Address { get; set; }
        public string OrderName { get; set; }
        public string PhoneNumber { get; set; }
        public string Notes { get; set; }
    }
}

namespace HybridWaiterServiceLayer.Mapper
{
    using AutoMapper;
    public class AutoMapperOrder : Profile
    {
        public AutoMapperOrder()
        {
            CreateMap<DTO.Order, ORDER>().ReverseMap();

        }
    }
}
