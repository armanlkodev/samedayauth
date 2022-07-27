using SameDayAuth.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SameDayAuth.Controllers
{
    public class SameDayApiController : ApiController
    {
        [Authorize]
        [HttpPost]
        [Route("SaveTicket")]
        public HttpResponseMessage SaveTicket(Tickets tkt)
        {
            try
            {
                //
                db_a8998a_samedayEntities objEntity = new db_a8998a_samedayEntities();
                String cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                Ticket objTicket = new Ticket();
                objTicket.OrderId = tkt.OrderId;
                objTicket.Subject = tkt.Subject;
                objTicket.MobileNo = tkt.MobileNo;
                objTicket.Discription = tkt.Discription;
                objEntity.Tickets.Add(objTicket);

                SqlCommand sqlCmd = new SqlCommand("Select OrderId,Subject,MobileNo,Discription from Tickets", con);
                SqlDataReader reader = sqlCmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["OrderId"].ToString().ToUpper() == tkt.OrderId.ToUpper())
                        if (reader["Subject"].ToString().ToUpper() == tkt.Subject.ToUpper())
                            if (reader["MobileNo"].ToString().ToUpper() == tkt.MobileNo.ToUpper())
                                if (reader["Discription"].ToString().ToUpper() == tkt.Discription.ToUpper())

                                {
                                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Already Exits");

                                }


                }
                objEntity.SaveChanges();

                if (tkt != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Successfully Submitted");

                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Please fill all the  details ");
                }

            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



    }


    //public IEnumerable<Ticket> Get()
    //{
    //    using (SameDayEntities entities = new SameDayEntities())
    //    {

    //        return entities.Tickets.ToList();
    //    }

    //}
}
