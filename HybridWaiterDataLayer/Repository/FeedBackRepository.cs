using HybridWaiterDataLayer.Infrastructure;
using HybridWaiterDataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridWaiterDataLayer.Repository
{
    public interface IFeedBackRepository : IBaseRepository<FEEDBACK>
    {
        Task<IEnumerable<FEEDBACK>> GetFeedBackByClient(int clientId);
        Task<IEnumerable<FEEDBACK>> GetFeedBackByClientEmail(string email);
        Task<IEnumerable<FEEDBACK>> GetFeedBackByDate(DateTime fromDate, DateTime toDate);

    }
    public class FeedBackRepository : BaseRepository<FEEDBACK>, IFeedBackRepository
    {
        public FeedBackRepository(HybridWaiterModel dataContext) : base(dataContext)
        {
        }
        public async Task<IEnumerable<FEEDBACK>> GetFeedBackByClient(int clientId)
        {
            //FEEDBACK data = new FEEDBACK();
            //data = await this.dbContext.FeedBacks.Where(x => x.ClientId == clientId).FirstOrDefaultAsync();
            //return data;
            IEnumerable<FEEDBACK> feedBacks = await this.dbContext.FeedBacks.Where(x => x.ClientId == clientId).OrderByDescending(x => x.CreationDate).ToListAsync();
            return feedBacks;
        }

        public async Task<IEnumerable<FEEDBACK>> GetFeedBackByClientEmail(string email)
        {
            //FEEDBACK data = new FEEDBACK();
            //data = await this.dbContext.FeedBacks.Include(x => x.Client)
            //    .Where(x => x.Client.Email == email).FirstAsync();
            //return data;
            IEnumerable<FEEDBACK> feedBacks = await this.dbContext.FeedBacks.Where(x => x.Client.Email == email).OrderByDescending(x => x.CreationDate).ToListAsync();
            return feedBacks;
        }

        public async Task<IEnumerable<FEEDBACK>> GetFeedBackByDate(DateTime fromDate, DateTime toDate)
        {
            IEnumerable<FEEDBACK> feedBacks = await this.dbContext.FeedBacks
                .Where(x => x.CreationDate >= fromDate && x.CreationDate <= toDate).OrderByDescending(x => x.CreationDate).ToListAsync();
            return feedBacks;
        }
    }
}
