using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GigALoan_Model
{
    [DataContract]
    public class DTO_SPRT_LoanCompany
    {
        [DataMember]
        public int CompanyID { get; set; }

        [DataMember]
        public string CompanyName { get; set; }

        [DataMember]
        public string CompanyState { get; set; }
    }
}
