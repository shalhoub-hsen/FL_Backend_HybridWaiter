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
    public interface ITeamMemberService: IServiceBase<TEAMMEMBER, TeamMember>
    {
        Task<IEnumerable<TeamMember>> GetMembersByPosition(int positionId);
        Task<IEnumerable<TeamMember>> GetMembersByPositionValue(string value);
        Task<IEnumerable<TeamMember>> GetMembersByDate(DateTime fromDate, DateTime toDate);
    }
    public class TeamMemberService: ServiceBase<TEAMMEMBER, TeamMember>, ITeamMemberService
    {
        ITeamMemberRepository repository;
        IMapper mapper;
        public TeamMemberService(ITeamMemberRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<TeamMember>> GetMembersByPosition(int positionId)
        {
            IEnumerable<TEAMMEMBER> team = await repository.GetMembersByPosition(positionId);
            return mapper.Map<IEnumerable<TeamMember>>(team);
        }
        public async Task<IEnumerable<TeamMember>> GetMembersByPositionValue(string value)
        {
            IEnumerable<TEAMMEMBER> team = await repository.GetMembersByPositionValue(value);
            return mapper.Map<IEnumerable<TeamMember>>(team);
        }
        public async Task<IEnumerable<TeamMember>> GetMembersByDate(DateTime fromDate, DateTime toDate)
        {
            IEnumerable<TEAMMEMBER> team = await repository.GetMembersByDate(fromDate, toDate);
            return mapper.Map<IEnumerable<TeamMember>>(team);
        }

    }
}
