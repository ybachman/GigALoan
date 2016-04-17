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
    public class DTO_CORE_Gig
    {
        [DataMember]
        public int GigID { get; set; }
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public int AlertID { get; set; }

        //public DateTime DateAccepted { get; set; }
        //[DataMember(Name = "DateAccepted")]
        //private string CreationDateForSerialization { get; set; }

        //[OnSerializing]
        //void OnSerializing(StreamingContext context)
        //{
        //    this.CreationDateForSerialization = JsonConvert.SerializeObject(this.DateAccepted).Replace('"', ' ').Trim();
        //    this.ClosingDateForSerialization = JsonConvert.SerializeObject(this.DateClosed).Replace('"', ' ').Trim();
        //}
        //[OnDeserialized]
        //void OnDeserialized(StreamingContext context)
        //{
        //    this.DateAccepted = DateTime.Parse(this.CreationDateForSerialization);
        //    this.DateClosed = DateTime.Parse(this.ClosingDateForSerialization);
        //}

        //public DateTime DateClosed { get; set; }
        //[DataMember(Name = "DateClosed")]
        //private string ClosingDateForSerialization { get; set; }

        [DataMember]
        public double StudentRating { get; set; }
        [DataMember]
        public double ClientRating { get; set; }
        [DataMember]
        public string StudentComments { get; set; }
        [DataMember]
        public string ClientComments { get; set; }
    }
}
