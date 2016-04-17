using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GigALoan_Model
{
    [DataContract]
    public class DTO_CHLD_ClientImage
    {
        [DataMember]
        public int ImageID { get; set; }

        [DataMember]
        public int ClientID { get; set; }

        [DataMember]
        public string ImageURL { get; set; }

        [DataMember]
        public string ImageUUID { get; set; }

        [DataMember]
        public string ImageName { get; set; }
    }
}
