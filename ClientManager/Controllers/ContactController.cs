using System.Collections.Generic;
using BLL.Contracts;
using Common.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactInformation _contactInformation;

        public ContactController(IContactInformation contactInformation)
        {
            _contactInformation = contactInformation;
        }

        [HttpGet("[action]")]
        [Route("Contact/GetContactInformation")]
        public List<ContactInformationDTO> GetContactInformation(long id)
        {
            return _contactInformation.GetContactInformation(id);
        }

        [HttpPost("[action]")]
        [Route("Contact/AddContactInformation")]
        public long AddContactInformation(ContactInformationDTO model)
        {
            return _contactInformation.AddContactInformation(model);
        }

        [HttpPost("[action]")]
        [Route("Contact/EditContactInformation")]
        public void EditContactInformation(ContactInformationDTO model)
        {
            _contactInformation.EditContactInformation(model);
        }

        [HttpPost("[action]")]
        [Route("Contact/DeleteContactInformation")]
        public void DeleteContactInformation(ContactInformationDTO model)
        {
            _contactInformation.DeleteContactInformation(model);
        }
    }
}