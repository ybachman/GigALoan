using System.Collections.Generic;
using System.ServiceModel;
using GigALoan_Model;
using System.ServiceModel.Web;

namespace GigALoan_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/FindAlertByID", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<DTO_CORE_GigAlert> FindAlertByID(DTO_CORE_GigAlert request);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/FindAlertsByPay", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<DTO_CORE_GigAlert> FindAlertsByPay(DTO_CORE_GigAlert request);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/FindAlertsByType", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<DTO_CORE_GigAlert> FindAlertsByType(DTO_CORE_GigAlert request);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/FindGigByAlertID", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<DTO_CORE_Gig> FindGigByAlertID(DTO_CORE_GigAlert request);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/FindGigsByStudentID", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<DTO_CORE_Gig> FindGigsByStudentID(DTO_CORE_Student request);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/FindGigsByClientID", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<DTO_CORE_Gig> FindGigsByClientID(DTO_CORE_Client request);
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/GetStudentAccount", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<DTO_CORE_Student> GetStudentAccount(DTO_CORE_Student request);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/GetClientAccount", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<DTO_CORE_Client> GetClientAccount(DTO_CORE_Client request);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/GetCollegeByID", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<DTO_SPRT_College> GetCollegeByID(DTO_SPRT_College request);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/GetColleges", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<DTO_SPRT_College> GetColleges();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/GetMajorByID", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<DTO_SPRT_Major> GetMajorByID(DTO_SPRT_Major request);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/GetMajors", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<DTO_SPRT_Major> GetMajors();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/GetGigTypeByID", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<DTO_SPRT_GigType> GetGigTypeByID(DTO_SPRT_GigType request);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/GetGigs", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<DTO_SPRT_GigType> GetGigs(DTO_SPRT_GigType request);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/GetGigTypeByCategoryID", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<DTO_SPRT_GigType> GetGigTypeByCategoryID(DTO_SPRT_GigType request);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/GetGigCategoryByID", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<DTO_SPRT_GigCategory> GetGigCategoryByID(DTO_SPRT_GigCategory request);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/GetGigCategories", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<DTO_SPRT_GigCategory> GetGigCategories();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/GetLoanCompanyByID", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<DTO_SPRT_LoanCompany> GetLoanCompanyByID(DTO_SPRT_LoanCompany request);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/GetGigLoanCompanies", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<DTO_SPRT_LoanCompany> GetGigLoanCompanies();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/CreateGig", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<DTO_CORE_Gig> CreateGig(DTO_CORE_Gig request);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/GetClientByID", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<DTO_CORE_Client> GetClientById(DTO_CORE_Client request);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/GetClientByName", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<DTO_CORE_Client> GetClientByName(DTO_CORE_Client request);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/GetClientByEmail", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<DTO_CORE_Client> GetClientByEmail(DTO_CORE_Client request);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/AddStudent", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        DTO_CORE_Student AddStudent(DTO_CORE_Student request);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/AddClient", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
       DTO_CORE_Client AddClient(DTO_CORE_Client request);
    }
}
