using Spotzer.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Spotzer.Helper.EnumHelper;

namespace Spotzer.Models
{
    public class PartnerD : OrderRequest, IPartner
    {
        public List<string> Validate()
        {
            var exceptionList = new List<string>();

            if (this.LineItems.Any(x => x.ProductType == ProductTypeEnum.Website.GetDescription()))
            {
                exceptionList.Add("You dont have permission for product type: " + ProductTypeEnum.Website.GetDescription());
            }

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