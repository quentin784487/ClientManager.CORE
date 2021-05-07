using BLL.Contracts;
using Common.Shared;
using Repository.Contracts;
using System.Collections.Generic;

namespace BLL
{
    public class AddressInformation : IAddressInformation
    {
        private readonly IAddressInformationRepository _addressInformationRepository;

        public AddressInformation(IAddressInformationRepository addressInformationRepository)
        {
            _addressInformationRepository = addressInformationRepository;
        }

        public long AddAddressInformation(AddressInformationDTO model)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("clients_Id", model.Clients_Id);
            parameters.Add("addressLine1", model.AddressLine1);
            parameters.Add("addressLine2", model.AddressLine2);
            parameters.Add("addressLine3", model.AddressLine3);
            parameters.Add("type", model.Type);
            parameters.Add("postalCode", model.PostalCode);

            return _addressInformationRepository.AddAddressInformation(parameters);
        }

        public void DeleteAddressInformation(AddressInformationDTO model)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("id", model.Id);

            _addressInformationRepository.DeleteAddressInformation(parameters);
        }

        public void EditAddressInformation(AddressInformationDTO model)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("id", model.Id);
            parameters.Add("addressLine1", model.AddressLine1);
            parameters.Add("addressLine2", model.AddressLine2);
            parameters.Add("addressLine3", model.AddressLine3);
            parameters.Add("type", model.Type);
            parameters.Add("postalCode", model.PostalCode);

            _addressInformationRepository.EditAddressInformation(parameters);
        }

        public List<AddressInformationDTO> GetAddressInformation(long id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            return (List<AddressInformationDTO>)_addressInformationRepository.GetAddressInformation(parameters).listItems;
        }
    }
}
