using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spotzer.Models
{
    public interface IPartner
    {
        List<string> Validate(OrderRequest orderRequest);

        BaseResponse Process();
    }
}