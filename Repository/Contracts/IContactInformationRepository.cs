using DAL.DataModel;
using System.Collections.Generic;

namespace Repository.Contracts
{
    public interface IContactInformationRepository
    {
        long AddContactInformation(Dictionary<string, object> model);
        void EditContactInformation(Dictionary<string, object> model);
        void DeleteContactInformation(Dictionary<string, object> model);
        PageResult GetContactInformation(Dictionary<string, object> model);
    }
}
