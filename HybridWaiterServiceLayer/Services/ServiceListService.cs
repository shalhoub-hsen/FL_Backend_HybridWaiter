using AutoMapper;
using HybridWaiterDataLayer.Models;
using HybridWaiterDataLayer.Repository;
using HybridWaiterServiceLayer.DTO;
using HybridWaiterServiceLayer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridWaiterServiceLayer.Services
{

    public interface IServiceListService: IServiceBase<SERVICELIST, ServiceList>
    {
        Task<ServiceList> GetServiceByName(string name);
    }
    public class ServiceListService: ServiceBase<SERVICELIST, ServiceList>, IServiceListService
    {
        IServiceListRepository repository;
        IMapper mapper;
        public ServiceListService(IServiceListRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ServiceList> GetServiceByName(string name)
        {
            SERVICELIST servicelist = await repository.GetServiceByName(name);
            return mapper.Map<ServiceList>(servicelist);
        }
    }
}
