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
    public interface IPositionRepository : IBaseRepository<POSITION>
    {
        Task<IEnumerable<POSITION>> GetAllPositions();
        Task<POSITION> GetPositionByValue(string value);
    }
    public class PositionRepository : BaseRepository<POSITION>, IPositionRepository
    {
        public PositionRepository(HybridWaiterModel dataContext) : base(dataContext) { }  
        
        public async Task<IEnumerable<POSITION>> GetAllPositions()
        {
            IEnumerable<POSITION> positions = await this.dbContext.Positions.Where(x => x.IsDeleted == null || x.IsDeleted == false).ToListAsync();
            return positions;
        }

        public async Task<POSITION> GetPositionByValue(string value)
        {
            POSITION position = new POSITION();
            position = await this.dbContext.Positions.Where(x => x.Values == value).FirstAsync();
            return position;
        }
    }
}
