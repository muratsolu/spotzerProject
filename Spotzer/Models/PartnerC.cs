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


        public List<string> Validate(OrderRequest orderRequest)
        {
            throw new NotImplementedException();
        }

        public BaseResponse Process()
        {
            throw new NotImplementedException();
        }
    }
}