using Common.Shared;
using DAL.DataModel;
using DAL.DbContext;
using Repository.Contracts;
using System.Collections.Generic;

namespace Repository
{
    public class ContactInformationRepository : IContactInformationRepository
    {
        private readonly IDataWrapper _dataWrapper;

        public ContactInformationRepository(IDataWrapper dataWrapper)
        {
            _dataWrapper = dataWrapper;
        }

        public long AddContactInformation(Dictionary<string, object> model)
        {
            return (long)_dataWrapper.ExecuteNonQuery("sp_addContactInformation", model);
        }

        public void DeleteContactInformation(Dictionary<string, object> model)
        {
            _dataWrapper.ExecuteNonQuery("sp_deleteContactInformation", model);
        }

        public void EditContactInformation(Dictionary<string, object> model)
        {
            _dataWrapper.ExecuteNonQuery("sp_editContactInformation", model);
        }

        public PageResult GetContactInformation(Dictionary<string, object> model)
        {
            return _dataWrapper.ExecuteDataReader<ContactInformation>("sp_getContactInformation", model, typeof(ContactInformation));
        }
    }
}
