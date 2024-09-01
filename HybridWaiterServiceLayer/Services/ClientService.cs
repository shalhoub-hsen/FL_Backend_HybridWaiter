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
    public interface IClientService : IServiceBase<CLIENT, DTO.Client>
    {
        Task<Client?> GetClientByMail(string mail);
        Task<(bool,int, string)> IsValidClient(string mail, string password);
        Task<bool> SaveClient(Client client);
    } 
    public class ClientService : ServiceBase<CLIENT, DTO.Client>, IClientService 
    {
        IClientRepository repository;
        IMapper mapper;
        public ClientService(IClientRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

       
        public async Task<Client> GetClientByMail(string mail)
        {
           CLIENT? client = await repository.GetClientByMail(mail);
            return mapper.Map<DTO.Client>(client);
        }

        public async Task<(bool,int, string)> IsValidClient(string mail, string password)
        {
            return await repository.IsValidClient(mail, password);
        }

        public async Task<bool> SaveClient(Client client)
        {
            CLIENT newClient = new CLIENT()
            {
                Id = 0,
                FirstName = client.FirstName,
                MiddleName = client.MiddleName,
                LastName = client.LastName,
                Email = client.Email,
                CreationDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                Password = client.Password
            };
            return await repository.SaveClient(mapper.Map<CLIENT>(client));
        }


    }
}
