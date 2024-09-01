using AutoMapper;
using HybridWaiterDataLayer.Models;
using HybridWaiterDataLayer.Repository;
using HybridWaiterServiceLayer.DTO;
using HybridWaiterServiceLayer.Infrastructure;
using HybridWaiterServiceLayer.UIModels;

namespace HybridWaiterServiceLayer.Services
{
    public interface IOrderService : IServiceBase<ORDER, Order>
    {
        Task PlaceOrder(int clientId, OrderView orderView);
    }

    public class OrderService : ServiceBase<ORDER, Order>, IOrderService
    {
        IOrderRepository repository;
        IMapper mapper;
        public OrderService(IOrderRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task PlaceOrder(int clientId, OrderView orderView)
        {
            ORDER finalOrder = new ORDER()
            {
                Id = 0,
                ClientId = clientId,
                CreationDate = DateTime.Now,
                OrderTypeId = 9,
                OrderStatusId = 12,
                Address = orderView.Address,
                PhoneNumber = orderView.PhoneNumber,
                OrderName = orderView.OrderName,
                Notes = orderView.Notes,
                OrderDetails = mapper.Map<IEnumerable<ORDER_DETAIL>>(orderView.OrderDetails)
            };

            await repository.PlaceOrder(finalOrder);
        }
    }
}
