using Common.Shared;
using System.Collections.Generic;

namespace BLL.Contracts
{
    public interface IContactInformation
    {
        long AddContactInformation(ContactInformationDTO model);
        void EditContactInformation(ContactInformationDTO model);
        void DeleteContactInformation(ContactInformationDTO model);
        List<ContactInformationDTO> GetContactInformation(long id);
    }
}
