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

    public interface IClientRepository : IBaseRepository<CLIENT>
    {
        Task<CLIENT?> GetClientByMail(string mail);
        Task<(bool,int, string)> IsValidClient(string mail, string password);
        Task<bool> SaveClient(CLIENT client);   
    }
    public class ClientRepository : BaseRepository<CLIENT>, IClientRepository
    {
        public ClientRepository(HybridWaiterModel dataContext) : base(dataContext) 
        {
        }

        public async Task<CLIENT?> GetClientByMail(string mail)
        {
            CLIENT? client = new CLIENT();
            client = await this.dbContext.CLients.Where(x => (x.IsDeleted == null || x.IsDeleted == false) && x.Email == mail)?.FirstOrDefaultAsync();
            return client;
        }

        public async Task<(bool,int, string)> IsValidClient(string mail, string password)
        {
            CLIENT? client = new CLIENT();
            client = await this.dbContext.CLients.Where(x => (x.IsDeleted == null || x.IsDeleted == false) && x.Email == mail && x.Password == password)?.FirstOrDefaultAsync();
            return client == null ? (false,0,"") : (true,client.Id, client.FirstName+" "+ client.LastName);
        }

        public async Task<bool> SaveClient(CLIENT client)  
        {
            try
            {
                this.dbContext.CLients.Add(client);
                await this.dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
