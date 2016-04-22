using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GigALoan_Model
{
    [DataContract]
    public class DTO_Image
    {
        [DataMember]
        public string ImageBytes { get; set; }

        [DataMember]
        public string ImageName { get; set; }

        [DataMember]
        public int OwnerID { get; set; }
    }
}
