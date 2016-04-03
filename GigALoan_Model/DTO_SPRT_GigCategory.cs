using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GigALoan_Model
{
    [DataContract]
    public class DTO_SPRT_GigCategory
    {
        public DTO_SPRT_GigCategory()
        { }

        public DTO_SPRT_GigCategory(int id, string categoryName)
        {
            this.CategoryID = id;
            this.CategoryName = categoryName;
        }

        [DataMember]
        public int CategoryID { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
    }
}
