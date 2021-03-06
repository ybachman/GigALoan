﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GigALoan_Model;
using GigALoan_DAL;
using System.Data.SqlClient;
using System.IO;
using System.Net;

namespace GigALoan_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service.svc or Service.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        private const string FTPURLBASE = "ftp://jumpcreek.com/";

        public List<DTO_CORE_GigAlert> FindAlertByID(DTO_CORE_GigAlert request)
        {
            List<DTO_CORE_GigAlert> results = new List<DTO_CORE_GigAlert>();

            using (DB_connection context = new GigALoan_DAL.DB_connection())
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

            if (request == null)
                return new List<DTO_CORE_GigAlert> { new DTO_CORE_GigAlert { Comment = "empty request" } };
            else if (results.Count == 0)
                return new List<DTO_CORE_GigAlert> { new DTO_CORE_GigAlert { Comment = "empty response" } };
            else
                return results;
        }

        public List<DTO_CORE_GigAlert> FindAlertsByPay(DTO_CORE_GigAlert request)
        {
            using (DB_connection context = new GigALoan_DAL.DB_connection())
            {

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

                if (request == null)
                    return new List<DTO_CORE_GigAlert> { new DTO_CORE_GigAlert { Comment = "empty request" } };
                else if (results.Count == 0)
                    return new List<DTO_CORE_GigAlert> { new DTO_CORE_GigAlert { Comment = "empty response" } };
                else
                    return results;
            }
        }

        public List<DTO_CORE_GigAlert> FindAlertsByType(DTO_CORE_GigAlert request)
        {
            using (DB_connection context = new GigALoan_DAL.DB_connection())
            {

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
        }

        public List<DTO_CORE_Gig> FindGigByAlertID(DTO_CORE_GigAlert request)
        {
            List<DTO_CORE_Gig> results = new List<DTO_CORE_Gig>();

            using (DB_connection context = new GigALoan_DAL.DB_connection())
            {
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
        }

        public List<DTO_CORE_Gig> FindGigsByStudentID(DTO_CORE_Student request)
        {
            List<DTO_CORE_Gig> results = new List<DTO_CORE_Gig>();

            using (DB_connection context = new GigALoan_DAL.DB_connection())
            {
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
        }

        public List<DTO_CORE_Gig> FindGigsByClientID(DTO_CORE_Client request)
        {
            List<DTO_CORE_Gig> results = new List<DTO_CORE_Gig>();

            using (DB_connection context = new GigALoan_DAL.DB_connection())
            {
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

        public List<DTO_CORE_Student> GetStudentAccount(DTO_CORE_Student request)
        {
            using (DB_connection context = new GigALoan_DAL.DB_connection())
            {
                List<DTO_CORE_Student> returnObject = new List<DTO_CORE_Student>();

                var studentList = context.CORE_Students.ToList();

                DTO_CORE_Student successfulMatchedStudent = null;

                foreach (var student in studentList)
                {
                    if (request.Email.ToLower() == student.Email.ToLower())
                    {
                        if (request.Pass == student.Pass)
                        {
                            successfulMatchedStudent = new DTO_CORE_Student();

                            successfulMatchedStudent.StudentID = student.StudentID;
                            successfulMatchedStudent.FirstName = student.FirstName;
                            successfulMatchedStudent.LastName = student.LastName;
                            successfulMatchedStudent.DateJoined = student.DateJoined;
                            successfulMatchedStudent.Email = student.Email;
                            successfulMatchedStudent.Pass = student.Pass;
                            successfulMatchedStudent.MajorID = student.MajorID;
                            successfulMatchedStudent.CollegeID = student.CollegeID;
                            successfulMatchedStudent.Gender = student.Gender;

                            if (student.Employed != null)
                            {
                                successfulMatchedStudent.Employed = (bool)student.Employed;
                            }

                            successfulMatchedStudent.Employer = student.Employer;
                            successfulMatchedStudent.PhoneNumber = student.PhoneNumber;

                            returnObject.Add(successfulMatchedStudent);

                            return returnObject;

                        }
                    }
                }
                return null;
            }
        }

        public List<DTO_CORE_Client> GetClientAccount(DTO_CORE_Client request)
        {
            using (DB_connection context = new GigALoan_DAL.DB_connection())
            {
                var clientList = context.CORE_Clients.ToList();

                DTO_CORE_Client successfulMatchedClient = null;

                var returnObject = new List<DTO_CORE_Client>();

                foreach (var client in clientList)
                {
                    if (request.Email.ToLower() == client.Email.ToLower())
                    {
                        if (request.Pass == client.Pass)
                        {
                            successfulMatchedClient = new DTO_CORE_Client();

                            successfulMatchedClient.ClientID = client.ClientID;
                            successfulMatchedClient.FirstName = client.FirstName;
                            successfulMatchedClient.LastName = client.LastName;
                            successfulMatchedClient.DateJoined = client.DateJoined;
                            successfulMatchedClient.Email = client.Email;
                            successfulMatchedClient.Pass = client.Pass;
                            successfulMatchedClient.Gender = client.Gender;
                            successfulMatchedClient.PhoneNumber = client.PhoneNumber;

                            if (client.Active != null)
                            {
                                successfulMatchedClient.Active = (bool)client.Active;
                            }

                            returnObject.Add(successfulMatchedClient);

                            return returnObject;
                        }
                    }
                }

                return null;
            }
        }

        public List<DTO_SPRT_College> GetCollegeByID(DTO_SPRT_College request)
        {
            using (DB_connection context = new GigALoan_DAL.DB_connection())
            {
                var returnObject = new List<DTO_SPRT_College>();

                var college = context.proc_GetColleges().Where(col => col.CollegeID == request.CollegeID).Single();

                DTO_SPRT_College result = new DTO_SPRT_College(college.CollegeID, college.CollegeName);

                if (result != null)
                {
                    returnObject.Add(result);
                }

                return returnObject;
            }
        }

        public List<DTO_SPRT_College> GetColleges()
        {
            List<DTO_SPRT_College> returnObject = new List<DTO_SPRT_College>();
            using (DB_connection context = new GigALoan_DAL.DB_connection())
            {
                var list = context.proc_GetColleges().ToList();

                foreach (var entity in list)
                {
                    returnObject.Add(new DTO_SPRT_College(entity.CollegeID, entity.CollegeName));
                }

                return returnObject;
            }
        }

        public List<DTO_SPRT_Major> GetMajorByID(DTO_SPRT_Major request)
        {
            using (DB_connection context = new GigALoan_DAL.DB_connection())
            {
                var major = context.proc_GetMajors().Where(m => m.MajorID == request.MajorID).Single();

                var returnObject = new List<DTO_SPRT_Major>();

                DTO_SPRT_Major result;


                if (major != null)
                {
                    result = new DTO_SPRT_Major(major.MajorID, major.MajorName);
                    returnObject.Add(result);
                }

                return returnObject;
            }
        }

        public List<DTO_SPRT_Major> GetMajors()
        {
            List<DTO_SPRT_Major> returnObject = new List<DTO_SPRT_Major>();

            using (DB_connection context = new GigALoan_DAL.DB_connection())
            {
                var list = context.proc_GetMajors().ToList();

                foreach (var entity in list)
                {
                    returnObject.Add(new DTO_SPRT_Major(entity.MajorID, entity.MajorName));
                }

                return returnObject;
            }
        }

        public List<DTO_SPRT_GigType> GetGigTypeByID(DTO_SPRT_GigType request)
        {

            using (DB_connection context = new GigALoan_DAL.DB_connection())
            {

                var returnObject = new List<DTO_SPRT_GigType>();

                var gigType = context.proc_GetGigTypes().Where(gt => gt.typeid == request.TypeID).Single();

                if (gigType != null)
                {
                    DTO_SPRT_GigType result = new DTO_SPRT_GigType(gigType.typeid, gigType.TypeName);
                    returnObject.Add(result);
                }

                return returnObject;
            }
        }

        public List<DTO_SPRT_GigType> GetGigs(DTO_SPRT_GigType request)
        {
            List<DTO_SPRT_GigType> results = new List<DTO_SPRT_GigType>();

            using (DB_connection context = new GigALoan_DAL.DB_connection())
            {
                var list = context.proc_GetGigTypes().ToList();

                foreach (var entity in list)
                {
                    results.Add(new DTO_SPRT_GigType(entity.typeid, entity.TypeName));
                }

                return results;
            }
        }

        public List<DTO_SPRT_GigType> GetGigTypeByCategoryID(DTO_SPRT_GigType request)
        {
            List<DTO_SPRT_GigType> results = new List<DTO_SPRT_GigType>();

            using (DB_connection context = new GigALoan_DAL.DB_connection())
            {
                var list = context.proc_GetGigTypes().Where(gt => gt.CategoryID == request.CategoryID).ToList();

                foreach (var entity in list)
                {
                    results.Add(new DTO_SPRT_GigType(entity.typeid, entity.TypeName));
                }

                return results;
            }
        }

        public List<DTO_SPRT_GigCategory> GetGigCategoryByID(DTO_SPRT_GigCategory request)
        {
            using (DB_connection context = new GigALoan_DAL.DB_connection())
            {
                var returnObject = new List<DTO_SPRT_GigCategory>();

                var gigCategory = context.SPRT_GigCategories.Where(gc => gc.CategoryID == request.CategoryID).Single();

                if (gigCategory != null)
                {
                    var gig = new DTO_SPRT_GigCategory(gigCategory.CategoryID, gigCategory.Category);

                    returnObject.Add(gig);
                }

                return returnObject;
            }
        }

        public List<DTO_SPRT_GigCategory> GetGigCategories()
        {
            using (DB_connection context = new GigALoan_DAL.DB_connection())
            {
                List<DTO_SPRT_GigCategory> results = new List<DTO_SPRT_GigCategory>();

                var list = context.SPRT_GigCategories.ToList();

                foreach (var entity in list)
                {
                    results.Add(new DTO_SPRT_GigCategory(entity.CategoryID, entity.Category));
                }

                return results;
            }
        }

        public List<DTO_SPRT_LoanCompany> GetLoanCompanyByID(DTO_SPRT_LoanCompany request)
        {
            using (DB_connection context = new GigALoan_DAL.DB_connection())
            {

                var returnObject = new List<DTO_SPRT_LoanCompany>();

                var loanCompany = context.SPRT_LoanCompanies.Where(lc => lc.CompanyID == request.CompanyID).Single();

                DTO_SPRT_LoanCompany result = new DTO_SPRT_LoanCompany
                {
                    CompanyID = loanCompany.CompanyID,
                    CompanyName = loanCompany.CompanyName,
                    CompanyState = loanCompany.CompanyState
                };

                returnObject.Add(result);

                return returnObject;
            }
        }

        public List<DTO_SPRT_LoanCompany> GetGigLoanCompanies()
        {
            List<DTO_SPRT_LoanCompany> results = new List<DTO_SPRT_LoanCompany>();
            using (DB_connection context = new GigALoan_DAL.DB_connection())
            {

                var list = context.SPRT_LoanCompanies.ToList();

                foreach (var entity in list)
                {
                    results.Add(new DTO_SPRT_LoanCompany
                    {
                        CompanyID = entity.CompanyID,
                        CompanyName = entity.CompanyName,
                        CompanyState = entity.CompanyState
                    });
                }
            }

            return results;

        }

        public List<DTO_CORE_Gig> CreateGig(DTO_CORE_Gig request)
        {

            using (DB_connection context = new GigALoan_DAL.DB_connection())
            {

                CORE_Gigs newgig = new CORE_Gigs
                {
                    AlertID = request.AlertID,
                    StudentID = request.StudentID,
                    ClientComments = request.ClientComments,
                    StudentRating = 0,
                    ClientRating = 0
                };

                if (context.CORE_GigAlerts.Where(ga => ga.AlertID == request.AlertID).Single().Active == true)
                {
                    context.CORE_Gigs.Add(newgig);

                    var alert = (from a in context.CORE_GigAlerts
                                 where a.AlertID == request.AlertID
                                 select a).Single();

                    alert.Active = false;
                    context.SaveChanges();
                }

                //string insertString = "IF ((SELECT Active FROM CORE_GigAlerts WHERE AlertID = " + request.AlertID + ") = 1) " +
                //    "INSERT INTO CORE_Gigs(AlertID, DateAccepted, StudentID, ClientComments, StudentRating, ClientRating) VALUES(" +
                //    request.AlertID + ", " + request.DateAccepted.ToString("yyyy-mm-dd") + ", " + request.StudentID + ", '" + request.ClientComments + "', 0, 0) " +
                //    "UPDATE CORE_GigAlerts SET Active = 0 FROM CORE_GigAlerts WHERE AlertID = " + request.AlertID;

                //SqlConnection connection = new SqlConnection();
                //connection.ConnectionString = "Server=tcp:s05.winhost.com;Database=DB_42039_gig;User ID=DB_42039_gig_user;Password=gigaloan";

                //SqlCommand cmd = new SqlCommand(insertString, connection);
                //connection.Open();
                //cmd.ExecuteNonQuery();
                //connection.Close();

                //var result = context.CORE_Gigs.Where(g => g.AlertID == request.AlertID).Single();

                DTO_CORE_Gig gigToBeReturned = new DTO_CORE_Gig
                {
                    AlertID = newgig.AlertID,
                    ClientComments = newgig.ClientComments,
                    ClientRating = 0.0,
                    DateAccepted = newgig.DateAccepted,
                    DateClosed = Convert.ToDateTime(null),
                    GigID = newgig.GigID,
                    StudentComments = "",
                    StudentID = newgig.StudentID,
                    StudentRating = 0.0
                };

                var returnObject = new List<DTO_CORE_Gig>();

                returnObject.Add(gigToBeReturned);

                return returnObject;
            }
        }

        public List<DTO_CORE_Client> GetClientByID(DTO_CORE_Client request)
        {

            using (DB_connection context = new DB_connection())
            {
                var resultList = context.CORE_Clients.Where(client => client.ClientID == request.ClientID).ToList();
                var result = new List<DTO_CORE_Client>();

                foreach (var client in resultList)
                {
                    var clientByName = new DTO_CORE_Client
                    {
                        ClientID = client.ClientID,
                        FirstName = client.FirstName,
                        LastName = client.LastName,
                        DateJoined = client.DateJoined,
                        Email = client.Email,
                        Pass = client.Pass,
                        Gender = client.Gender,
                        PhoneNumber = client.PhoneNumber,
                        Active = (bool)client.Active
                    };
                    result.Add(clientByName);
                }

                return result;
            }

        }//end method GetClientById

        //method used to get a client by their name
        public List<DTO_CORE_Client> GetClientByName(DTO_CORE_Client request)
        {
            using (DB_connection context = new DB_connection())
            {
                var resultList = context.CORE_Clients.Where(client => client.FirstName == request.FirstName &&
                                                           client.LastName == request.LastName).ToList();//FirstOrDefault();

                var result = new List<DTO_CORE_Client>();

                foreach (var client in resultList)
                {
                    var clientByName = new DTO_CORE_Client
                    {
                        ClientID = client.ClientID,
                        FirstName = client.FirstName,
                        LastName = client.LastName,
                        DateJoined = client.DateJoined,
                        Email = client.Email,
                        Pass = client.Pass,
                        Gender = client.Gender,
                        PhoneNumber = client.PhoneNumber,
                        Active = (bool)client.Active
                    };
                    result.Add(clientByName);
                }
                return result;
            }
        }//end method GetClientByEmail

        //method used to get a client by their email
        public List<DTO_CORE_Client> GetClientByEmail(DTO_CORE_Client request)
        {
            using (DB_connection context = new DB_connection())
            {
                var resultList = context.CORE_Clients.Where(client => client.Email == request.Email).ToList();

                var result = new List<DTO_CORE_Client>();

                foreach (var client in resultList)
                {
                    var clientByName = new DTO_CORE_Client
                    {
                        ClientID = client.ClientID,
                        FirstName = client.FirstName,
                        LastName = client.LastName,
                        DateJoined = client.DateJoined,
                        Email = client.Email,
                        Pass = client.Pass,
                        Gender = client.Gender,
                        PhoneNumber = client.PhoneNumber,
                        Active = (bool)client.Active
                    };
                    result.Add(clientByName);
                }

                return result;
            }
        }//end method GetClientByEmail

        //method used to add a client to the DB
        public DTO_CORE_Client AddClient(DTO_CORE_Client request)
        {
            using (DB_connection context = new DB_connection())
            {
                var outputParameter = new System.Data.Entity.Core.Objects.ObjectParameter("new_identity", typeof(int));

                var id = context.proc_AddClient(request.FirstName, request.LastName, request.Email,
                     request.Pass, request.Gender, request.PhoneNumber, outputParameter);

                id = (int)outputParameter.Value;

                if (id == -1)
                {
                    return null;//client is already in the system
                }
                else if (id >= 1)
                {
                    return request;
                }
                else
                {
                    //issue adding client
                    return null;
                }
            }
        }//end method AddClient 

        public DTO_CORE_Student AddStudent(DTO_CORE_Student request)
        {
            using (DB_connection context = new DB_connection())
            {
                var outputParameter = new System.Data.Entity.Core.Objects.ObjectParameter("new_identity", typeof(int));

                var id = context.proc_AddStudent(request.FirstName, request.LastName,
                request.Email, request.Pass, request.MajorID, request.CollegeID,
                request.Gender, request.Employed, request.Employer, request.PhoneNumber,
                outputParameter);

                id = (int)outputParameter.Value;

                if (id == -1)
                {
                    return null;//client is already in the system
                }
                else if (id >= 1)
                {
                    return request;
                }
                else
                {
                    //issue adding client
                    return null;
                }
            }
        }//end method AddStudent 

        public List<DTO_CORE_Student> GetStudentByID(DTO_CORE_Student request)
        {
            using (DB_connection context = new DB_connection())
            {
                var resultList = context.CORE_Students.Where(student => student.StudentID == request.StudentID).ToList();
                var result = new List<DTO_CORE_Student>();

                foreach (var student in resultList)
                {
                    var studentByID = new DTO_CORE_Student
                    {
                        StudentID = student.StudentID,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        Email = student.Email,
                        Employed = (bool)student.Employed,
                        Employer = student.Employer,
                        MajorID = student.MajorID,
                        CollegeID = student.CollegeID,
                        Pass = student.Pass,
                        Gender = student.Gender,
                        PhoneNumber = student.PhoneNumber,
                        Active = (bool)student.Active
                    };
                    result.Add(studentByID);
                }

                return result;
            }
        }

        public List<DTO_CORE_Student> GetStudentByName(DTO_CORE_Student request)
        {
            //Create a list of type DTO_CORE_Student
            using (DB_connection context = new DB_connection())
            {

                var resultList = context.CORE_Students.Where(student => student.LastName == request.LastName || student.FirstName == student.FirstName); //Needs to also recognize a full name (Firt Last and Last First)
                var result = new List<DTO_CORE_Student>();

                foreach (var student in resultList)
                {
                    var studentByName = new DTO_CORE_Student
                    {
                        StudentID = student.StudentID,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        Email = student.Email,
                        Employed = (bool)student.Employed,
                        Employer = student.Employer,
                        MajorID = student.MajorID,
                        CollegeID = student.CollegeID,
                        Pass = student.Pass,
                        Gender = student.Gender,
                        PhoneNumber = student.PhoneNumber,
                        Active = (bool)student.Active
                    };
                    result.Add(studentByName);
                }

                return result;
            }
        }

        public List<DTO_CORE_Student> GetStudentByEmail(DTO_CORE_Student request)
        {
            //Create a list of type DTO_CORE_Student
            using (DB_connection context = new DB_connection())
            {

                var resultList = context.CORE_Students.Where(student => student.Email == request.Email || student.Email.Contains(request.Email)).ToList();
                var result = new List<DTO_CORE_Student>();

                foreach (var student in resultList)
                {
                    var studentByEmail = new DTO_CORE_Student
                    {
                        StudentID = student.StudentID,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        Email = student.Email,
                        Employed = (bool)student.Employed,
                        Employer = student.Employer,
                        MajorID = student.MajorID,
                        CollegeID = student.CollegeID,
                        Pass = student.Pass,
                        Gender = student.Gender,
                        PhoneNumber = student.PhoneNumber,
                        Active = (bool)student.Active
                    };
                    result.Add(studentByEmail);
                }
                return result;
            }
        }

        public DTO_CHLD_StudentImage AddStudentImage(DTO_Image request)
        {
            byte[] imageBytes = Convert.FromBase64String(request.ImageBytes);

            Stream fileStream = new MemoryStream(imageBytes);

            using (var context = new DB_connection())
            {
                var student = context.CORE_Students.FirstOrDefault(s => s.StudentID == request.OwnerID);

                if (student == null)
                    return null;

                var result = new DTO_CHLD_StudentImage
                {
                    ImageName = request.ImageName,
                    ImageURL = FTPURLBASE,
                    ImageUUID = Guid.NewGuid().ToString(),
                    StudentID = request.OwnerID
                };

                try
                {
                    var ftpRequest = (FtpWebRequest)WebRequest.Create(result.ImageURL + result.ImageUUID + result.ImageName);
                    ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;

                    ftpRequest.Credentials = new NetworkCredential("jumpcree_gigaloan", "gigaloan");

                    using (Stream ftpStream = ftpRequest.GetRequestStream())
                    {
                        int length = 1024;
                        byte[] buffer = new byte[length];
                        int bytesRead = 0;

                        do
                        {
                            bytesRead = fileStream.Read(buffer, 0, length);
                            ftpStream.Write(buffer, 0, bytesRead);
                        } while (bytesRead != 0);
                    }
                }
                catch (WebException e)
                {
                    return null;
                }

                result.ImageURL += "images/"; //long story....

                context.proc_AddStudentImage(result.StudentID, result.ImageURL, result.ImageUUID, result.ImageName);
                context.SaveChanges();

                return result;
            }
        }

        public List<DTO_CHLD_StudentImage> GetStudentImages(DTO_CORE_Student request)
        {
            using (var context = new DB_connection())
            {
                var imageList = context.proc_GetStudentImages(request.StudentID).ToList();

                List<DTO_CHLD_StudentImage> results = new List<DTO_CHLD_StudentImage>();

                foreach(var image in imageList)
                {
                    results.Add(new DTO_CHLD_StudentImage
                    {
                        ImageID = image.ImageID,
                        ImageName = image.ImageName,
                        ImageURL = image.ImageURL,
                        ImageUUID = image.ImageUUID
                    });
                }

                return results;
            }
        }
    }
}
