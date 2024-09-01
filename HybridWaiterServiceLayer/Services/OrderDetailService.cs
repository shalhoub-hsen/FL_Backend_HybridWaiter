using AutoMapper;
using HybridWaiterDataLayer.Models;
using HybridWaiterDataLayer.Repository;
using HybridWaiterServiceLayer.DTO;
using HybridWaiterServiceLayer.Infrastructure;

namespace HybridWaiterServiceLayer.Services
{
    public interface IOrderDetailService : IServiceBase<ORDER_DETAIL, OrderDetail>
    {

    }

    public class OrderDetailService : ServiceBase<ORDER_DETAIL, OrderDetail>, IOrderDetailService
    {
        IOrderDetailRepository repository;
        IMapper mapper;
        public OrderDetailService(IOrderDetailRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
    }
}
