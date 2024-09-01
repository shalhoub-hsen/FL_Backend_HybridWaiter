using AutoMapper;
using HybridWaiterDataLayer.Infrastructure;
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
    public interface IPositionService : IServiceBase<POSITION, Position>
    {
        Task<IEnumerable<Position>> GetAllPositions();
        Task<Position> GetPositionByValue(string value);
    }
    public class PositionService : ServiceBase<POSITION, Position>, IPositionService
    {
        IPositionRepository repository;
        IMapper mapper;
        public PositionService(IPositionRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Position>> GetAllPositions()
        {
            IEnumerable<POSITION> positions = await repository.GetAllPositions();
            return mapper.Map<IEnumerable<Position>>(positions);
        }

        public async Task<Position> GetPositionByValue(string value)
        {
            POSITION position = await repository.GetPositionByValue(value);
            return mapper.Map<Position>(position);

        }
    }
}
