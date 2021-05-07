using DAL.DataModel;
using System.Collections.Generic;

namespace Repository.Contracts
{
    public interface IAddressInformationRepository
    {
        long AddAddressInformation(Dictionary<string, object> model);
        void EditAddressInformation(Dictionary<string, object> model);
        void DeleteAddressInformation(Dictionary<string, object> model);
        PageResult GetAddressInformation(Dictionary<string, object> model);
    }
}
