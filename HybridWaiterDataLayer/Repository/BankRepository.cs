using HybridWaiterDataLayer.Infrastructure;
using HybridWaiterDataLayer.Models;
namespace HybridWaiterDataLayer.Repository
{
    public interface IBankRepository : IBaseRepository<BANK>
    {
    }
    public class BankRepository : BaseRepository<BANK>, IBankRepository
    {
        public BankRepository(HybridWaiterModel dataContext) : base(dataContext)
        {

        }
    }
}
