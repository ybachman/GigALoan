using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GigALoan_Model
{
    [DataContract]
    public class DTO_CHLD_StudentImage
    {
        public DTO_CHLD_StudentImage()
        { }

        public DTO_CHLD_StudentImage(int studentID, string imageName)
        {
            this.StudentID = studentID;
            this.ImageName = imageName;
        }

        [DataMember]
        public int ImageID { get; set; }
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public string ImageURL { get; set; }
        [DataMember]
        public string ImageUUID { get; set; }
        [DataMember]
        public string ImageName { get; set; }

    }
}
