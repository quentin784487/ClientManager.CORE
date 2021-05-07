using System.Data.Common;

namespace DAL.DataModel
{
    public class ContactInformation : Model
    {
        public long Clients_Id { get; set; }
        public string ContactAddress { get; set; }
        public string Type { get; set; }

        public override void Populate(DbDataReader reader)
        {
            Id = GetLong(reader, "Id", -1);
            Clients_Id = GetLong(reader, "Clients_Id", -1);
            ContactAddress = GetString(reader, "ContactAddress", null);
            Type = GetString(reader, "Type", null);
        }
    }
}
