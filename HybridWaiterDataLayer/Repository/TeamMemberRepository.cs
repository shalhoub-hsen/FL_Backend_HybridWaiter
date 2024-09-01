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

    public interface ITeamMemberRepository : IBaseRepository<TEAMMEMBER>
    {
        Task<IEnumerable<TEAMMEMBER>> GetMembersByPosition(int positionId);
        Task<IEnumerable<TEAMMEMBER>> GetMembersByPositionValue(string value);
        Task<IEnumerable<TEAMMEMBER>> GetMembersByDate(DateTime fromDate, DateTime toDate);
    }
    public class TeamMemberRepository : BaseRepository<TEAMMEMBER>, ITeamMemberRepository
    {
        public TeamMemberRepository(HybridWaiterModel dataContext) : base(dataContext) { }  

        public async Task<IEnumerable<TEAMMEMBER>> GetMembersByPosition(int positionId)
        {
            IEnumerable<TEAMMEMBER> members = await this.dbContext.TeamMembers.Where(x => (x.IsDeleted == null || x.IsDeleted == false) &&
            x.PositionId == positionId).ToListAsync();
            return members;
        }

        public async Task<IEnumerable<TEAMMEMBER>> GetMembersByPositionValue(string value)
        {
            IEnumerable<TEAMMEMBER> members = await this.dbContext.TeamMembers.Where(x => (x.IsDeleted == null || x.IsDeleted == false) &&
            x.Position.Values == value).ToListAsync();
            return members;
        }

        public async Task<IEnumerable<TEAMMEMBER>> GetMembersByDate(DateTime fromDate, DateTime toDate)
        {
            IEnumerable<TEAMMEMBER> members = await this.dbContext.TeamMembers
                .Where(x => x.CreationDate >= fromDate && x.CreationDate <= toDate).OrderByDescending(x => x.CreationDate).ToListAsync();
            return members;
        }
    }
}
