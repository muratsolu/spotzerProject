using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spotzer.Models
{
    public class PartnerC : OrderRequest, IPartner
    {
        // Extra Fields
        public string ExposureID { get; set; }
        public string UDAC { get; set; }
        public string RelatedOrder { get; set; }


        public List<string> Validate()
        {
            var errorList = new List<string>();
            if (String.IsNullOrEmpty(this.ExposureID))
                errorList.Add("ExposureID cannot be null");
            if (String.IsNullOrEmpty(this.UDAC))
                errorList.Add("UDAC cannot be null");
            if (String.IsNullOrEmpty(this.RelatedOrder))
                errorList.Add("RelatedOrder cannot be null");

            return errorList;
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