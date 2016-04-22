using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace GigALoan_Model
{
    [DataContract]
    public class DTO_CORE_Student
    {
        [DataMember]
        public int StudentID { get; set; }
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
            this.DateJoined = DateTime.Parse(this.CreationDateForSerialization);
        }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Pass { get; set; }
        [DataMember]
        public int MajorID { get; set; }
        [DataMember]
        public int CollegeID { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public bool Employed { get; set; }
        [DataMember]
        public string Employer { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public bool Active { get; set; }
    }
}
