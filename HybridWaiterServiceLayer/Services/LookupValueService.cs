using AutoMapper;
using HybridWaiterDataLayer.Models;
using HybridWaiterDataLayer.Repository;
using HybridWaiterServiceLayer.DTO;
using HybridWaiterServiceLayer.Infrastructure;

namespace HybridWaiterServiceLayer.Services
{
    public interface ILookupValueService : IServiceBase<LOOKUP_VALUE, LookupValue>
    {

    }
    public class LookupValueService : ServiceBase<LOOKUP_VALUE, LookupValue>, ILookupValueService
    {
        ILookupValueRepository repository;
        IMapper mapper;
        public LookupValueService(ILookupValueRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
    }
}
