using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GigALoan_Model
{
    [DataContract]
    public class DTO_SPRT_Major
    {
        public DTO_SPRT_Major()
        { }

        public DTO_SPRT_Major(int id, string name)
        {
            this.MajorID = id;
            this.MajorName = name;
        }

        [DataMember]
        public int MajorID { get; set; }
        [DataMember]
        public string MajorName { get; set; }
    }
}
