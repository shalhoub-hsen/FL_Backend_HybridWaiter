using HybridWaiterDataLayer.Infrastructure;
using HybridWaiterDataLayer.Models;

namespace HybridWaiterDataLayer.Repository
{
    public interface IOrderDetailRepository : IBaseRepository<ORDER_DETAIL>
    {
    }

    public class OrderDetailRepository : BaseRepository<ORDER_DETAIL>, IOrderDetailRepository
    {
        public OrderDetailRepository(HybridWaiterModel dataContext) : base(dataContext)
        {

        }
    }
}
