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
    public interface IFeedBackService : IServiceBase<FEEDBACK, FeedBack>
    {
        Task<IEnumerable<FeedBack>> GetFeedBackByClient(int clientId);
        Task<IEnumerable<FeedBack>> GetFeedBackByClientEmail(string email);
        Task<IEnumerable<FeedBack>> GetFeedBackByDate(DateTime fromDate, DateTime toDate);
    }
    public class FeedBackService : ServiceBase<FEEDBACK, FeedBack>, IFeedBackService
    {
        IFeedBackRepository repository;
        IMapper mapper;
        public FeedBackService(IFeedBackRepository repository, IMapper mapper): base(repository, mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<FeedBack>> GetFeedBackByClient(int clientId)
        {
            IEnumerable<FEEDBACK> feedBacks = await repository.GetFeedBackByClient(clientId);
            return mapper.Map<IEnumerable<FeedBack>>(feedBacks);
        }

        public async Task<IEnumerable<FeedBack>> GetFeedBackByClientEmail(string email)
        {
            IEnumerable<FEEDBACK> feedBacks = await repository.GetFeedBackByClientEmail(email);
            return mapper.Map<IEnumerable<FeedBack>>(feedBacks);
        }

        public async Task<IEnumerable<FeedBack>> GetFeedBackByDate(DateTime fromDate, DateTime toDate)
        {
            IEnumerable<FEEDBACK> feedBacks = await repository.GetFeedBackByDate(fromDate, toDate);
            return mapper.Map<IEnumerable<FeedBack>> (feedBacks);
        }
    }
}
