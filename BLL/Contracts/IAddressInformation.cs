using Common.Shared;
using System.Collections.Generic;

namespace BLL.Contracts
{
    public interface IAddressInformation
    {        
        long AddAddressInformation(AddressInformationDTO model);
        void EditAddressInformation(AddressInformationDTO model);
        void DeleteAddressInformation(AddressInformationDTO model);
        List<AddressInformationDTO> GetAddressInformation(long id);
    }
}
