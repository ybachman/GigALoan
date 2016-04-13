using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace GigALoan_Model
{
    // Some comment
    [DataContract]
    public class DTO_CORE_Client
    {
        [DataMember]
        public int ClientID { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        public DateTime DateJoined { get; set; }
        [DataMember(Name = "DateJoined")]
        private string CreationDateForSerialization { get; set; }
        [OnSerializing]
        void OnSerializing(StreamingContext context)
        {
           
            this.CreationDateForSerialization = JsonConvert.SerializeObject(this.DateJoined).Replace('"', ' ').Trim();
          
           
        }
        [OnDeserialized]
        void OnDeserialized(StreamingContext context)
        {
            if (this.CreationDateForSerialization != null)
                this.DateJoined = DateTime.Parse(this.CreationDateForSerialization);
        }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Pass { get; set; }

        [DataMember]
        public string Gender { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public bool Active { get; set; }
    }
}
