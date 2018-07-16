using Spotzer.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using static Spotzer.Helper.EnumHelper;

namespace Spotzer.Models
{
    public class PartnerA : ProcessOrder
    {

        public override List<string>  Validate(OrderRequest orderRequest)
        {
            var exceptionList = new List<string>();

            if (orderRequest.LineItems.Any(x => x.ProductType == ProductTypeEnum.PaidSearch.GetDescription()))
            {
                exceptionList.Add("You dont have permission for product type: " + ProductTypeEnum.PaidSearch.GetDescription());
            }

            return exceptionList;
        }

        public override BaseResponse Process(OrderRequest orderRequest)
        {
            var response =new  BaseResponse();
            try
            {
                response.ErrorList = Validate(orderRequest);

                if (response.ErrorList.Count > 0)
                {
                    response.IsSuccess = false;
                    response.httpResponseMessage = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                //loggin exception to db or somewhere else
                
                response.ErrorList.Add("Cannot process order, please contact system administrator!");
                response.IsSuccess = false;
                response.httpResponseMessage = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
            }

            return response;
        }
    }
}