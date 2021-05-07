using System;
using System.Data.Common;

namespace DAL.DataModel
{
    public class Client : Model
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IDNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Gender { get; set; }

        public override void Populate(DbDataReader reader)
        {
            Id = GetLong(reader, "Id", -1);
            Name = GetString(reader, "Name", null);
            Surname = GetString(reader, "Surname", null);
            IDNumber = GetString(reader, "IDNumber", null);
            CreatedDate = GetDateTime(reader, "CreatedDate");
            Gender = GetString(reader, "Gender", null);
        }
    }
}
