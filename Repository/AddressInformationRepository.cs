using DAL.DataModel;
using DAL.DbContext;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class AddressInformationRepository : IAddressInformationRepository
    {
        private readonly IDataWrapper _dataWrapper;

        public AddressInformationRepository(IDataWrapper dataWrapper)
        {
            _dataWrapper = dataWrapper;
        }

        public PageResult GetAddressInformation(Dictionary<string, object> model)
        {
            return _dataWrapper.ExecuteDataReader<AddressInformation>("sp_getAddressInformation", model, typeof(AddressInformation));
        }

        public long AddAddressInformation(Dictionary<string, object> model)
        {
            return (long)_dataWrapper.ExecuteNonQuery("sp_addAddressInformation", model);
        }

        public void EditAddressInformation(Dictionary<string, object> model)
        {
            _dataWrapper.ExecuteNonQuery("sp_editAddressInformation", model);
        }

        public void DeleteAddressInformation(Dictionary<string, object> model)
        {
            _dataWrapper.ExecuteNonQuery("sp_deleteAddressInformation", model);
        }
    }
}
