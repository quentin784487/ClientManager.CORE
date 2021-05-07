using Common.Shared;
using System.Collections.Generic;

namespace BLL.Contracts
{
    public interface IClients
    {
        long AddClient(ClientDTO model);
        void EditClient(ClientDTO model);
        void DeleteClient(ClientDTO model);
        PagedClientDTO GetClients(ClientDTO model, int pageIndex, int pageSize);
        ClientDTO GetClient(long id);
        byte[] ExportClients();
    }
}
