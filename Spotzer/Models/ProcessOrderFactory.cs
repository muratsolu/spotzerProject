using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using static Spotzer.Helper.EnumHelper;

namespace Spotzer.Models
{
    public class ProcessOrderFactory
    {
        public IPartner CreateInstance(JObject orderRequest)
        {
            string partnerCode = orderRequest.GetValue("Partner", StringComparison.InvariantCultureIgnoreCase).Value<string>();
            PartnerEnum partnerEnum;
            if (Enum.TryParse(partnerCode, out partnerEnum))
            {
                switch (partnerEnum)
                {
                    case PartnerEnum.A:
                        return orderRequest.ToObject<PartnerA>();

                    case PartnerEnum.B:
                        return orderRequest.ToObject<PartnerB>();

                    case PartnerEnum.C:
                        return orderRequest.ToObject<PartnerC>();

                    case PartnerEnum.D:
                        return orderRequest.ToObject<PartnerD>();

                }
            }

            throw new Exception("Invalid Partner");
        }
    }
}