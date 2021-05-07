using Common.Shared;
using DAL.DataModel;
using DAL.DbContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contracts
{
    public class ClientsRepository : IClientsRepository
    {
        private readonly IDataWrapper _dataWrapper;

        public ClientsRepository(IDataWrapper dataWrapper)
        {
            _dataWrapper = dataWrapper;
        }

        public long AddClient(Dictionary<string, object> model)
        {
            return (long)_dataWrapper.ExecuteNonQuery("sp_addClients", model);
        }

        public void DeleteClient(Dictionary<string, object> model)
        {
            _dataWrapper.ExecuteNonQuery("sp_deleteClients", model);
        }

        public void EditClient(Dictionary<string, object> model)
        {
            _dataWrapper.ExecuteNonQuery("sp_editClients", model);
        }        

        public PageResult GetClients(Dictionary<string, object> model)
        {
            return _dataWrapper.ExecuteDataReader<Client>("sp_getClients", model, typeof(Client));
        }

        public PageResult GetClient(Dictionary<string, object> model)
        {
            return _dataWrapper.ExecuteDataReader<Client>("sp_getClient", model, typeof(Client));
        }

        public PageResult ExportClients()
        {
            return _dataWrapper.ExecuteDataReader<ClientReport>("sp_exportClients", null, typeof(ClientReport));
        }
    }
}
