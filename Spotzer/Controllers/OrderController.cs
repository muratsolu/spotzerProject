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
        public BaseResponse OrderProduct([FromBody]JObject orderJson)
        {
            IPartner partner = partnerFactory.CreateInstance(orderJson);
            var response = partner.Process();

            return response;
        }
    }
}
