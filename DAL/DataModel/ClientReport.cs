using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DAL.DataModel
{
    public class ClientReport : Model
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

        public override void Populate(DbDataReader reader)
        {
            Name = GetString(reader, "Name", null);
            Surname = GetString(reader, "Surname", null);
            IDNumber = GetString(reader, "IDNumber", null);
            CreatedDate = GetDateTime(reader, "CreatedDate");
            Gender = GetString(reader, "Gender", null);
            Address_Type = GetString(reader, "Address_Type", null);
            AddressLine1 = GetString(reader, "AddressLine1", null);
            AddressLine2 = GetString(reader, "AddressLine2", null);
            AddressLine3 = GetString(reader, "AddressLine3", null);
            PostalCode = GetString(reader, "PostalCode", null);
            Contact_Type = GetString(reader, "Name", null);
            ContactAddress = GetString(reader, "Name", null);
        }
    }
}
