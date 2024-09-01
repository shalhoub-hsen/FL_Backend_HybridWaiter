using HybridWaiterDataLayer.Infrastructure;
using HybridWaiterDataLayer.Models;

namespace HybridWaiterDataLayer.Repository
{
    public interface ILookupValueRepository : IBaseRepository<LOOKUP_VALUE>
    {
    }
    public class LookupValueRepository : BaseRepository<LOOKUP_VALUE>, ILookupValueRepository
    {
        public LookupValueRepository(HybridWaiterModel dataContext) : base(dataContext)
        {

        }
    }
}
