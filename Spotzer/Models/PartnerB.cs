using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spotzer.Models
{
    public class PartnerB : OrderRequest, IPartner
    {

        public List<string> Validate()
        {
            throw new NotSupportedException();
        }

        public BaseResponse Process()
        {
            var response = new BaseResponse();
            response.IsSuccess = true;
            return response;
        }
    }
}