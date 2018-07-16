using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spotzer.Models
{
    public abstract class ProcessOrder
    {
        public abstract List<string> Validate(OrderRequest orderRequest);

        public abstract BaseResponse Process(OrderRequest orderRequest);
    }
}