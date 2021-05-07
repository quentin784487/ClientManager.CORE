using System.Data.Common;

namespace DAL.DataModel
{
    public class AddressInformation : Model
    {
        public long Clients_Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Type { get; set; }
        public string PostalCode { get; set; }

        public override void Populate(DbDataReader reader)
        {
            Id = GetLong(reader, "Id", -1);
            Clients_Id = GetLong(reader, "Clients_Id", -1);
            AddressLine1 = GetString(reader, "AddressLine1", null);
            AddressLine2 = GetString(reader, "AddressLine2", null);
            AddressLine3 = GetString(reader, "AddressLine3", null);
            Type = GetString(reader, "Type", null);
            PostalCode = GetString(reader, "PostalCode", null);
        }
    }
}
