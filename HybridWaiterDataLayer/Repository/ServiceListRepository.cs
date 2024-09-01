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
    public interface IServiceListRepository : IBaseRepository<SERVICELIST>
    {
        Task<SERVICELIST> GetServiceByName(string name);
    }
    public class ServiceListRepository : BaseRepository<SERVICELIST>, IServiceListRepository
    {
        public ServiceListRepository(HybridWaiterModel dataContext) : base(dataContext) { }

        public async Task<SERVICELIST> GetServiceByName(string name)
        {
            SERVICELIST data = new SERVICELIST();
            data = await this.dbContext.ServiceLists.Where(x => (x.IsDeleted == null || x.IsDeleted == false) && x.Name == name).FirstAsync();
            return data;
        }
    }
}
