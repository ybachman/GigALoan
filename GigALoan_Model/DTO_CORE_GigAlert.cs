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
    public class DTO_CORE_GigAlert
    {
        public DTO_CORE_GigAlert()
        { }

        [DataMember]
        public int AlertID { get; set; }
        [DataMember]
        public int ClientID { get; set; }
        [DataMember]
        public int TypeID { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Comment { get; set; }
        [DataMember]
        public double PaymentAmt { get; set; }
        [DataMember]
        public double Long { get; set; }
        [DataMember]
        public double Lat { get; set; }
        
        public DateTime DateCreated { get; set; }
        [DataMember(Name = "DateCreated")]
        private string CreationDateForSerialization { get; set; }
        [OnSerializing]
        void OnSerializing(StreamingContext context)
        {
            this.CreationDateForSerialization = JsonConvert.SerializeObject(this.DateCreated).Replace('"', ' ').Trim();
        }
        [OnDeserialized]
        void OnDeserialized(StreamingContext context)
        {
            this.DateCreated = DateTime.Parse(this.CreationDateForSerialization);
        }

        [DataMember]
        public bool Active { get; set; }
    }
}
