using BLL.Contracts;
using Common.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClients _clients;

        public ClientsController(IClients clients)
        {
            _clients = clients;
        }

        [HttpGet("[action]")]
        [Route("Clients/GetClient")]
        public ClientDTO GetClient(long id)
        {
            return _clients.GetClient(id);
        }

        [HttpPost("[action]")]
        [Route("Clients/GetClients")]
        public PagedClientDTO GetClients([FromBody]ClientDTO model, [FromQuery] int pageIndex, [FromQuery] int pageSize)
        {
            return _clients.GetClients(model, pageIndex, pageSize);
        }

        [HttpPost("[action]")]
        [Route("Clients/AddClient")]
        public long AddClient(ClientDTO model)
        {
            return _clients.AddClient(model);
        }

        [HttpPost("[action]")]
        [Route("Clients/EditClient")]
        public void EditClient(ClientDTO model)
        {
            _clients.EditClient(model);
        }

        [HttpPost("[action]")]
        [Route("Clients/DeleteClient")]
        public void DeleteClient(ClientDTO model)
        {
            _clients.DeleteClient(model);
        }

        [HttpPost("[action]")]
        [Route("Clients/ExportClients")]
        public FileContentResult ExportClients()
        {
            byte[] bytes = _clients.ExportClients();
            var result = new FileContentResult(bytes, "application/octet-stream");
            result.FileDownloadName = "clients.csv";
            return result;
        }
    }
}
