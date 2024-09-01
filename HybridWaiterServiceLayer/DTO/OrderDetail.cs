using HybridWaiterDataLayer.Models;

namespace HybridWaiterServiceLayer.DTO
{
    public class OrderDetail : BaseDTO<ORDER_DETAIL>
    {
        public int OrderId { get; set; } = 0;
        public int FoodMenuId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}

namespace HybridWaiterServiceLayer.Mapper
{
    using AutoMapper;
    public class AutoMapperOrderDetail : Profile
    {
        public AutoMapperOrderDetail()
        {
            CreateMap<DTO.OrderDetail, ORDER_DETAIL>().ReverseMap();

        }
    }
}
