using System.Collections.Generic;
using BLL.Contracts;
using Common.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressInformation _addressInformation;

        public AddressController(IAddressInformation addressInformation)
        {
            _addressInformation = addressInformation;
        }

        [HttpGet("[action]")]
        [Route("Address/GetAddressInformation")]
        public List<AddressInformationDTO> GetAddressInformation(long id)
        {
            return _addressInformation.GetAddressInformation(id);
        }

        [HttpPost("[action]")]
        [Route("Address/AddAddressInformation")]
        public long AddAddressInformation(AddressInformationDTO model)
        {
            return _addressInformation.AddAddressInformation(model);
        }

        [HttpPost("[action]")]
        [Route("Address/EditAddressInformation")]
        public void EditAddressInformation(AddressInformationDTO model)
        {
            _addressInformation.EditAddressInformation(model);
        }

        [HttpPost("[action]")]
        [Route("Address/DeleteAddressInformation")]
        public void DeleteAddressInformation(AddressInformationDTO model)
        {
            _addressInformation.DeleteAddressInformation(model);
        }
    }
}