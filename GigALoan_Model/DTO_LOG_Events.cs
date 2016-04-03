using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

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
        [DataMember]
        public DateTime DateLogged { get; set; }
        [DataMember]
        public string LogMessage { get; set; }
    }
}
