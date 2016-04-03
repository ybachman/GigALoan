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
    }
}
