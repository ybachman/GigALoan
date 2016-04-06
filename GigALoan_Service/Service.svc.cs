using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GigALoan_Model;
using GigALoan_DAL;

namespace GigALoan_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service.svc or Service.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        public List<DTO_CORE_GigAlert> FindAlertByID(DTO_CORE_GigAlert request)
        {
            List<DTO_CORE_GigAlert> results = new List<DTO_CORE_GigAlert>();

            using (GigALoan_DAL.DB_connection context = new GigALoan_DAL.DB_connection())
            {
                if (request != null)
                {
                    var alertList = context.CORE_GigAlerts.Where(ga => ga.AlertID == request.AlertID).ToList();

                    foreach (var alert in alertList)
                    {
                        DTO_CORE_GigAlert result = new DTO_CORE_GigAlert
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
                        };
                        results.Add(result);
                    }
                }
            }

            return results;
        }

        public List<DTO_CORE_GigAlert> FindAlertsByPay(DTO_CORE_GigAlert request)
        {
            GigALoan_DAL.DB_connection context = new GigALoan_DAL.DB_connection();

            List<DTO_CORE_GigAlert> results = new List<DTO_CORE_GigAlert>();

            var alertList = context.CORE_GigAlerts.Where(ga => ga.PaymentAmt >= request.PaymentAmt);

            foreach (CORE_GigAlerts alert in alertList)
            {
                DTO_CORE_GigAlert result = new DTO_CORE_GigAlert
                {
                    AlertID = alert.AlertID,
                    TypeID = alert.TypeID,
                    Title = alert.Title,
                    Comment = alert.Comment,
                    Active = (bool)alert.Active,
                    ClientID = alert.ClientID,
                    DateCreated = alert.DateCreated,
                    Lat = alert.Lat,
                    Long = alert.Long,
                    PaymentAmt = alert.PaymentAmt
                    /*TODO: Get Alert images(or at least the first) loaded as well*/
                };
                results.Add(result);
            }

            return results;
        }

        public List<DTO_CORE_GigAlert> FindAlertsByType(DTO_CORE_GigAlert request)
        {
            GigALoan_DAL.DB_connection context = new GigALoan_DAL.DB_connection();

            List<DTO_CORE_GigAlert> results = new List<DTO_CORE_GigAlert>();

            var alertList = context.CORE_GigAlerts.Where(ga => ga.SPRT_GigTypes.TypeID == request.TypeID);

            foreach (CORE_GigAlerts alert in alertList)
            {
                DTO_CORE_GigAlert result = new DTO_CORE_GigAlert
                {
                    AlertID = alert.AlertID,
                    TypeID = alert.TypeID,
                    Title = alert.Title,
                    Comment = alert.Comment,
                    Active = (bool)alert.Active,
                    ClientID = alert.ClientID,
                    DateCreated = alert.DateCreated,
                    Lat = alert.Lat,
                    Long = alert.Long,
                    PaymentAmt = alert.PaymentAmt
                    /*TODO: Get Alert images(or at least the first) loaded as well*/
                };
                results.Add(result);
            }

            return results;
        }

        public List<DTO_CORE_Gig> FindGigByAlertID(DTO_CORE_GigAlert request)
        {
            List<DTO_CORE_Gig> results = new List<DTO_CORE_Gig>();

            GigALoan_DAL.DB_connection context = new GigALoan_DAL.DB_connection();

            var gigList = context.CORE_Gigs.Where(g => g.AlertID == request.AlertID).ToList();

            foreach (CORE_Gigs gig in gigList)
            {

                DTO_CORE_Gig result = new DTO_CORE_Gig
                {
                    GigID = gig.GigID,
                    StudentID = gig.StudentID,
                    AlertID = gig.AlertID,
                    DateAccepted = gig.DateAccepted,
                    StudentComments = gig.StudentComments,
                    ClientComments = gig.ClientComments
                };
                if (gig.DateClosed != null)
                    result.DateClosed = (DateTime)gig.DateClosed;
                if (gig.StudentRating != null)
                    result.StudentRating = (double)gig.StudentRating;
                if (gig.ClientRating != null)
                    result.ClientRating = (double)gig.ClientRating;

                results.Add(result);
            }

            return results;
        }

        public List<DTO_CORE_Gig> FindGigsByStudentID(DTO_CORE_Student request)
        {
            List<DTO_CORE_Gig> results = new List<DTO_CORE_Gig>();

            GigALoan_DAL.DB_connection context = new GigALoan_DAL.DB_connection();

            var gigList = context.CORE_Gigs.Where(g => g.StudentID == request.StudentID);

            foreach (CORE_Gigs gig in gigList)
            {
                DTO_CORE_Gig result = new DTO_CORE_Gig
                {
                    GigID = gig.GigID,
                    StudentID = gig.StudentID,
                    AlertID = gig.AlertID,
                    DateAccepted = gig.DateAccepted,
                    StudentComments = gig.StudentComments,
                    ClientComments = gig.ClientComments
                };

                if (gig.DateClosed != null)
                    result.DateClosed = (DateTime)gig.DateClosed;
                if (gig.StudentRating != null)
                    result.StudentRating = (double)gig.StudentRating;
                if (gig.ClientRating != null)
                    result.ClientRating = (double)gig.ClientRating;

                results.Add(result);
            }
            return results;
        }

        public List<DTO_CORE_Gig> FindGigsByClientID(DTO_CORE_Client request)
        {
            List<DTO_CORE_Gig> results = new List<DTO_CORE_Gig>();

            GigALoan_DAL.DB_connection context = new GigALoan_DAL.DB_connection();

            var gigList = context.CORE_Gigs.Where(g => g.CORE_GigAlerts.ClientID == request.ClientID);

            foreach (CORE_Gigs gig in gigList)
            {
                DTO_CORE_Gig result = new DTO_CORE_Gig
                {
                    GigID = gig.GigID,
                    StudentID = gig.StudentID,
                    AlertID = gig.AlertID,
                    DateAccepted = gig.DateAccepted,
                    StudentComments = gig.StudentComments,
                    ClientComments = gig.ClientComments                    
                };

                if (gig.DateClosed != null)
                    result.DateClosed = (DateTime)gig.DateClosed;
                if (gig.StudentRating != null)
                    result.StudentRating = (double)gig.StudentRating;
                if (gig.ClientRating != null)
                    result.ClientRating = (double)gig.ClientRating;

                results.Add(result);
            }
            return results;
        }
    }
}
