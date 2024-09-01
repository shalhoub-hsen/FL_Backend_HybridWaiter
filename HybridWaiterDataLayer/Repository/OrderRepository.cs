using HybridWaiterDataLayer.Infrastructure;
using HybridWaiterDataLayer.Models;
namespace HybridWaiterDataLayer.Repository
{
    public interface IOrderRepository : IBaseRepository<ORDER>
    {
        Task PlaceOrder(ORDER order);
    }

    public class OrderRepository : BaseRepository<ORDER>, IOrderRepository
    {
        public OrderRepository(HybridWaiterModel dataContext) : base(dataContext)
        {

        }

        public async Task PlaceOrder(ORDER order)
        {
            try
            {
                 dbContext.Orders.Add(order);

                await dbContext.SaveChangesAsync();

            }
            catch(Exception e)
            {
                throw;
            }
        }
    }
}
