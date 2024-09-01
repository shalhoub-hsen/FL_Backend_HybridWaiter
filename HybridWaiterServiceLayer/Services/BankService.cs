using AutoMapper;
using HybridWaiterDataLayer.Models;
using HybridWaiterDataLayer.Repository;
using HybridWaiterServiceLayer.DTO;
using HybridWaiterServiceLayer.Infrastructure;


namespace HybridWaiterServiceLayer.Services
{
    public interface IBankService : IServiceBase<BANK, Bank>
    {

    }
    public class BankService : ServiceBase<BANK, Bank>, IBankService
    {
        IBankRepository repository;
        IMapper mapper;
        public BankService(IBankRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
    }
}
