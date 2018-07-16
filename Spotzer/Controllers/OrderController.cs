using Spotzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Spotzer.Controllers
{
    public class OrderController : ApiController
    {
        public BaseResponse OrderProduct(OrderRequest orderRequest)
        {
            BaseResponse response = new BaseResponse();
            if (!ModelState.IsValid)
            {
                response.IsSuccess = false;
                response.httpResponseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            else
            {
                ProcessOrderFactory processOrderFactory = new ProcessOrderFactory();
                ProcessOrder processOrder = null;

                processOrder = processOrderFactory.CreateInstance(orderRequest.Partner);

                processOrder.Process(orderRequest);
            }

            return response;
        }
    }
}
