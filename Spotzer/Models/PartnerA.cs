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
    public class PartnerA : OrderRequest, IPartner
    {
        // Custom fields
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactTitle { get; set; }
        public string ContactPhone { get; set; }
        public string ContactMobile { get; set; }
        public string ContactEmail { get; set; }

        public List<string> Validate(OrderRequest orderRequest)
        {
            var exceptionList = new List<string>();

            if (orderRequest.LineItems.Any(x => x.ProductType == ProductTypeEnum.PaidSearch.GetDescription()))
            {
                exceptionList.Add("You dont have permission for product type: " + ProductTypeEnum.PaidSearch.GetDescription());
            }

            return exceptionList;
        }

        public BaseResponse Process()
        {
            var response = new BaseResponse();
            try
            {
                response.ErrorList = Validate(this);

                if (response.ErrorList.Count > 0)
                {
                    response.IsSuccess = false;
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
            }

            return response;
        }
    }
}