using System.Collections.Generic;

namespace Common.Shared
{
    public class PagedClientDTO
    {
        public int totalCount { get; set; }
        public List<ClientDTO> clients { get; set; }
        public PagedClientDTO(int totalCount)
        {
            this.totalCount = totalCount;
            clients = new List<ClientDTO>();
        }
    }
}
