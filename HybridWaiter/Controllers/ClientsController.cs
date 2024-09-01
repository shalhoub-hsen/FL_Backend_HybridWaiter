using HybridWaiterDataLayer.Models;
using HybridWaiterServiceLayer.DTO;
using HybridWaiterServiceLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HybridWaiterAPI.Controllers
{
    [Route("Clients")]
    [ApiController,Authorize]
    public class ClientsController: BaseController<CLIENT, Client>
    {
        IClientService service;
        public ClientsController(IClientService clientService) : base(clientService)
        {
            service = clientService;
        }
        //[HttpGet("GetClientById")]
        //public async Task<ActionResult> GetClientById(int Id)
        //{
        //    Client client = await service.Get(Id);
        //    return Ok(client);
        //}

        [HttpGet("GetClientByMail")]
        public async Task<ActionResult> GetClientByMail(string mail)
        {
            Client client = await service.GetClientByMail(mail);
            return Ok(client);
        }


    }
}
