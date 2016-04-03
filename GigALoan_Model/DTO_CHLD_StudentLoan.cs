using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GigALoan_Model
{
    [DataContract]
    public class DTO_CHLD_StudentLoan
    {
        public DTO_CHLD_StudentLoan()
        { }
        public DTO_CHLD_StudentLoan(int id, int studentID, int companyID, double loanAmount, string accountNum)
        {
            this.LoanID = id;
            this.StudentID = studentID;
            this.CompanyID = companyID;
            this.LoanAmount = loanAmount;
            this.AccountNumber = accountNum;
        }
        [DataMember]
        public int LoanID { get; set; }
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public int CompanyID { get; set; }
        [DataMember]
        public double LoanAmount { get; set; }
        [DataMember]
        public string AccountNumber { get; set; }

    }
}
