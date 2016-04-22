using Newtonsoft.Json;
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
        
        public DateTime DateAdded { get; set; }
        [DataMember(Name = "DateAdded")]
        private string CreationDateForSerialization { get; set; }

        [OnSerializing]
        void OnSerializing(StreamingContext context)
        {

            this.CreationDateForSerialization = JsonConvert.SerializeObject(this.DateAdded).Replace('"', ' ').Trim();


        }

        [OnDeserialized]
        void OnDeserialized(StreamingContext context)
        {
            if (this.CreationDateForSerialization != null)
                this.DateAdded = DateTime.Parse(this.CreationDateForSerialization);
        }
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
