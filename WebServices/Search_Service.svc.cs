using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GigALoan_Model;
namespace WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TestService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TestService.svc or TestService.svc.cs at the Solution Explorer and start debugging.
    public class TestService : Search_Service
    {
        public List<DTO_CORE_GigAlert> FindAlertByID(DTO_CORE_GigAlert request)
        {
            List<DTO_CORE_GigAlert> response = null;

            using (GigALoan_DAL.DB_connection context= new GigALoan_DAL.DB_connection())
            {
                if (request != null)
                {
                    var alertList = context.CORE_GigAlerts.Where(ga => ga.AlertID == request.AlertID).ToList();

                    foreach (var alert in alertList)
                    {
                        response = new List<DTO_CORE_GigAlert>();
                        response.Add(new DTO_CORE_GigAlert
                        {
                            Active = (bool)alert.Active,
                            AlertID = alert.AlertID,
                            ClientID = alert.ClientID,
                            Comment = alert.Comment,
                            DateCreated = alert.DateCreated,
                            Lat = alert.Lat,
                            Long = alert.Long,
                            PaymentAmt = alert.PaymentAmt,
                            Title = alert.Title,
                            TypeID = alert.TypeID
                        });
                    }
                }
            }

                return response;
        }
    }
}
