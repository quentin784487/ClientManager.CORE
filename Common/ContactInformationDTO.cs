using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Shared
{
    public class ContactInformationDTO
    {
        public long Id { get; set; }
        public long Clients_Id { get; set; }
        public string ContactAddress { get; set; }
        public string Type { get; set; }
    }
}
