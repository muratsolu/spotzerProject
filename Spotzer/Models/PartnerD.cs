using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spotzer.Models
{
    public class PartnerD : ProcessOrder
    {
        public override List<string> Validate(OrderRequest orderRequest)
        {
            throw new NotImplementedException();
        }

        public override BaseResponse Process(OrderRequest orderRequest)
        {
            throw new NotImplementedException();
        }
    }
}