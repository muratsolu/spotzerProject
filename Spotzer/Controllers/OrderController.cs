using Newtonsoft.Json.Linq;
using Spotzer.Helper;
using Spotzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace Spotzer.Controllers
{
    public class OrderController : ApiController
    {
        ProcessOrderFactory partnerFactory;
        public OrderController()
        {
            partnerFactory = new ProcessOrderFactory();
        }
        [HttpPost]
        public IHttpActionResult OrderProduct([FromBody]JObject orderJson)
        {
            if (orderJson == null)
                return Content(HttpStatusCode.BadRequest, "Invalid JSON");

            try
            {
                IPartner partner = partnerFactory.CreateInstance(orderJson);
                var response = partner.Process();
                return Content(HttpStatusCode.OK, response);
            }
            catch (NotSupportedException ex)
            {
                return Content(HttpStatusCode.NotAcceptable, ex.Message);
            }

        }
    }
}
