using System;

namespace Common.Shared
{
    public class ClientReportDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IDNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Gender { get; set; }
        public string Address_Type { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string PostalCode { get; set; }
        public string Contact_Type { get; set; }
        public string ContactAddress { get; set; }
    }
}
