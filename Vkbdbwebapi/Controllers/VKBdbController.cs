using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vkbdbwebapi.Models;

using Vkbdbwebapi;
using static Vkbdbwebapi.Models.Vkbdbconnection;

namespace Vkbdbwebapi.Controllers
{
    [RoutePrefix("m1/mani")]
    public class VKBdbController : ApiController
    {
        Vkbdbconnection vkdb;
        VKBdbController()
        {
            vkdb = new Vkbdbconnection();
        }
        //[Route("insertstudent")]
        //[HttpPost]
        //public HttpResponseMessage insertstudent(studentinsertrequest sir)
        //{
        //    HttpResponseMessage resp;
        //    string Errormessage = string.Empty;
        //    if (vkbdb.insertstudent(sir, ref Errormessage))

        //    {
        //        return resp = Request.CreateResponse(HttpStatusCode.OK, new { Data = "success", message = "success" });

        //    }
        //    return resp = Request.CreateErrorResponse(HttpStatusCode.NotFound, Errormessage);
        //}

        [Route("insertstudent1")]
        [HttpPost]
        public HttpResponseMessage insertstudentbyEF(student studentrequest)
        {
            HttpResponseMessage resp;
            string Errormessage = string.Empty;
           if(vkdb.insertstudentbyEF(studentrequest, ref Errormessage))

            {
                return resp = Request.CreateResponse(HttpStatusCode.OK, new { Data = "success", message = "success" });

            }
            return resp = Request.CreateErrorResponse(HttpStatusCode.NotFound, Errormessage);
        }

        [Route("insertfrnd")]
        [HttpPost]
        public HttpResponseMessage insertfriendbyEF(friend friendrequest)
        {
            HttpResponseMessage resp;
            string Errormessage = string.Empty;
            if(vkdb.insertfriendEF(friendrequest,ref Errormessage))

            {
                return resp = Request.CreateResponse(HttpStatusCode.OK, new { Data = "success", message = "success" });

            }
            return resp = Request.CreateErrorResponse(HttpStatusCode.NotFound, Errormessage);
        }
    }
    }

