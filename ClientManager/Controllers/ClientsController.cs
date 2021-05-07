using BLL.Contracts;
using Common.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClients _clients;
        private readonly IAddressInformation _addressInformation;
        private readonly IContactInformation _contactInformation;

        public ClientsController(IClients clients, IAddressInformation addressInformation, IContactInformation contactInformation)
        {
            _clients = clients;
            _addressInformation = addressInformation;
            _contactInformation = contactInformation;
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
            result.FileDownloadName = "my-csv-file.csv";
            return result;

        }

        //#######################################################################################

        [HttpGet("[action]")]
        [Route("Clients/GetAddressInformation")]
        public List<AddressInformationDTO> GetAddressInformation(long id)
        {
            return _addressInformation.GetAddressInformation(id);
        }

        [HttpPost("[action]")]
        [Route("Clients/AddAddressInformation")]
        public long AddAddressInformation(AddressInformationDTO model)
        {
            return _addressInformation.AddAddressInformation(model);
        }

        [HttpPost("[action]")]
        [Route("Clients/EditAddressInformation")]
        public void EditAddressInformation(AddressInformationDTO model)
        {
            _addressInformation.EditAddressInformation(model);
        }

        [HttpPost("[action]")]
        [Route("Clients/DeleteAddressInformation")]
        public void DeleteAddressInformation(AddressInformationDTO model)
        {
            _addressInformation.DeleteAddressInformation(model);
        }

        //#######################################################################################

        [HttpGet("[action]")]
        [Route("Clients/GetContactInformation")]
        public List<ContactInformationDTO> GetContactInformation(long id)
        {
            return _contactInformation.GetContactInformation(id);
        }

        [HttpPost("[action]")]
        [Route("Clients/AddContactInformation")]
        public long AddContactInformation(ContactInformationDTO model)
        {
            return _contactInformation.AddContactInformation(model);
        }

        [HttpPost("[action]")]
        [Route("Clients/EditContactInformation")]
        public void EditContactInformation(ContactInformationDTO model)
        {
            _contactInformation.EditContactInformation(model);
        }

        [HttpPost("[action]")]
        [Route("Clients/DeleteContactInformation")]
        public void DeleteContactInformation(ContactInformationDTO model)
        {
            _contactInformation.DeleteContactInformation(model);
        }
    }
}
