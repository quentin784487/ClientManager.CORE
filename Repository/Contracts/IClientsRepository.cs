using Common.Shared;
using DAL.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contracts
{
    public interface IClientsRepository
    {
        long AddClient(Dictionary<string, object> model);
        void EditClient(Dictionary<string, object> model);
        void DeleteClient(Dictionary<string, object> model);
        PageResult GetClients(Dictionary<string, object> model);
        PageResult GetClient(Dictionary<string, object> model);
        PageResult ExportClients();
    }
}
