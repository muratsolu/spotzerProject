﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spotzer.Models
{
    public class PartnerD : IPartner
    {
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