using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigALoan_Model
{
    public class DTO_CHLD_ClientImage
    {
        public int ImageID { get; set; }
        public int ClientID { get; set; }
        public string ImageURL { get; set; }
        public string ImageUUID { get; set; }
        public string ImageName { get; set; }
    }
}
