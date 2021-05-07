using System;
using System.Collections.Generic;

namespace Common.Shared
{    
    public class ClientDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IDNumber { get; set; }
        public string Gender { get; set; }     
        public DateTime? CreatedDate { get; set; }
        public List<AddressInformationDTO> AddressInformation { get; set; }
        public List<ContactInformationDTO> ContactInformation { get; set; }
    }
}
