using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigALoan_Model
{
    public class DTO_CORE_Client
    {
        public int ClientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateJoined { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public bool Active { get; set; }
    }
}
