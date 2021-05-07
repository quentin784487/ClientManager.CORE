using Common.Shared;
using Repository.Contracts;
using System.Collections.Generic;

namespace BLL.Contracts
{
    public class ContactInformation : IContactInformation
    {
        private readonly IContactInformationRepository _contactInformationRepository;

        public ContactInformation(IContactInformationRepository contactInformationRepository)
        {
            _contactInformationRepository = contactInformationRepository;
        }

        public long AddContactInformation(ContactInformationDTO model)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("clients_Id", model.Clients_Id);
            parameters.Add("contactAddress", model.ContactAddress);
            parameters.Add("type", model.Type);

            return _contactInformationRepository.AddContactInformation(parameters);
        }

        public void DeleteContactInformation(ContactInformationDTO model)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("id", model.Id);

            _contactInformationRepository.DeleteContactInformation(parameters);
        }

        public void EditContactInformation(ContactInformationDTO model)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("id", model.Id);
            parameters.Add("contactAddress", model.ContactAddress);
            parameters.Add("type", model.Type);

            _contactInformationRepository.EditContactInformation(parameters);
        }

        public List<ContactInformationDTO> GetContactInformation(long id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            return (List<ContactInformationDTO>)_contactInformationRepository.GetContactInformation(parameters).listItems;
        }
    }
}
