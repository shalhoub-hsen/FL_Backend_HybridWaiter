using HybridWaiterDataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridWaiterServiceLayer.DTO
{
    public class TeamMember :BaseDTO<TEAMMEMBER>
    {
        public string? ImageURL { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DOB { get; set; }
        public int? PositionId { get; set; }
        public DateTime? JoiningDate { get; set; }
        public bool? IsStill { get; set; }
    }
}

namespace HybridWaiterServiceLayer.Mapper
{
    using AutoMapper;
    public class AutoMapperTeamMember : Profile
    {
        public AutoMapperTeamMember()
        {
            CreateMap<DTO.TeamMember, TEAMMEMBER>().ReverseMap();

        }
    }
}

