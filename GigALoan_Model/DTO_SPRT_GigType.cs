using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GigALoan_Model
{
    [DataContract]
    public class DTO_SPRT_GigType
    {
        public DTO_SPRT_GigType()
        { }

        public DTO_SPRT_GigType(int id, string typeName)
        {
            this.TypeID = id;
            this.TypeName = typeName;
        }

        public DTO_SPRT_GigType(int id, string typeName, int categoryID)
        {
            this.TypeID = id;
            this.TypeName = typeName;
            this.CategoryID = categoryID;
        }

        [DataMember]
        public int TypeID { get; set; }
        [DataMember]
        public string TypeName { get; set; }
        [DataMember]
        public int CategoryID { get; set; }
    }
}
