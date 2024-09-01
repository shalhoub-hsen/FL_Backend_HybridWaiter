using HybridWaiterDataLayer.Models;
using HybridWaiterServiceLayer.DTO;
using HybridWaiterServiceLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HybridWaiterAPI.Controllers
{
    [ApiController]
    [Route("TeamMember")]
    public class TeamMemberController : BaseController<TEAMMEMBER, TeamMember>
    {
        ITeamMemberService service;
        public TeamMemberController(ITeamMemberService teamMemberService) : base(teamMemberService)
        {
            service = teamMemberService;
        }
        
        [HttpGet("GetMembersByPosition")]
        public async Task<ActionResult> GetMembersByPosition(int positionId)
        {
            IEnumerable<TeamMember> teamMembers = await service.GetMembersByPosition(positionId);
            return Ok(teamMembers);
        }
        
        [HttpGet("GetMembersByDate")]
        public async Task<ActionResult> GetMembersByDate(DateTime fromDate, DateTime toDate)
        {
            IEnumerable<TeamMember> teamMembers = await service.GetMembersByDate(fromDate, toDate);
            return Ok(teamMembers);
        }
    }
}
