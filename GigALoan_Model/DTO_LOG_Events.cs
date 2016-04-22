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
    public class DTO_LOG_Events
    {
        public DTO_LOG_Events()
        { }

        public DTO_LOG_Events(DateTime time, string message)
        {
            this.DateLogged = time;
            this.LogMessage = message;
        }

        public DTO_LOG_Events(int id, DateTime time, string message)
        {
            this.LogID = id;
            this.DateLogged = time;
            this.LogMessage = message;
        }

        [DataMember]
        public int LogID { get; set; }
        
        public DateTime DateLogged { get; set; }
        [DataMember(Name = "DateLogged")]
        private string CreationDateForSerialization { get; set; }

        [OnSerializing]
        void OnSerializing(StreamingContext context)
        {

            this.CreationDateForSerialization = JsonConvert.SerializeObject(this.DateLogged).Replace('"', ' ').Trim();
        }

        [OnDeserialized]
        void OnDeserialized(StreamingContext context)
        {
            if (this.CreationDateForSerialization != null)
                this.DateLogged = DateTime.Parse(this.CreationDateForSerialization);
        }
        [DataMember]
        public string LogMessage { get; set; }
    }
}
