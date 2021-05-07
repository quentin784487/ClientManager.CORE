namespace Common.Shared
{
    public class AddressInformationDTO
    {
        public long Id { get; set; }
        public long Clients_Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Type { get; set; }
        public string PostalCode { get; set; }
    }
}
