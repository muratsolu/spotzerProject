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

        public List<string> Validate()
        {
            var exceptionList = new List<string>();

            if (this.LineItems.Any(x => x.ProductType == ProductTypeEnum.PaidSearch.GetDescription()))
            {
                exceptionList.Add("You dont have permission for product type: " + ProductTypeEnum.PaidSearch.GetDescription());
            }

            if (String.IsNullOrEmpty(this.ContactFirstName))
                exceptionList.Add("ContactFirstName cannot be null");
            if (String.IsNullOrEmpty(this.ContactLastName))
                exceptionList.Add("ContactLastName cannot be null");
            if (String.IsNullOrEmpty(this.ContactTitle))
                exceptionList.Add("ContactTitle cannot be null");
            if (String.IsNullOrEmpty(this.ContactPhone))
                exceptionList.Add("ContactPhone cannot be null");
            if (String.IsNullOrEmpty(this.ContactMobile))
                exceptionList.Add("ContactMobile cannot be null");
            if (String.IsNullOrEmpty(this.ContactEmail))
                exceptionList.Add("ContactEmail cannot be null");

            return exceptionList;
        }

        public BaseResponse Process()
        {
            var response = new BaseResponse();
            try
            {
                response.ErrorList = Validate();

                if (response.ErrorList.Count > 0)
                {
                    response.IsSuccess = false;
                }
                else
                {
                    response.IsSuccess = true;
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