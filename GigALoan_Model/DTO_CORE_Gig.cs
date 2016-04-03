using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

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
        [DataMember]
        public DateTime DateAccepted { get; set; }
        [DataMember]
        public DateTime DateClosed { get; set; }
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
