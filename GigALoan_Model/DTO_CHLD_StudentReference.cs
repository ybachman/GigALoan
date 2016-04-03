using System;
using System.Runtime.Serialization;

namespace GigALoan_Model
{
    [DataContract]
    public class DTO_CHLD_StudentReference
    {
        public DTO_CHLD_StudentReference()
        { }

        [DataMember]
        public int RefID { get; set; }
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public int TypeID { get; set; }
        [DataMember]
        public DateTime DateAdded { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
    }
}
