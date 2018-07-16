using System;
using static Spotzer.Helper.EnumHelper;

namespace Spotzer.Models
{
    public class ProcessOrderFactory
    {
        public ProcessOrder CreateInstance(string partner)
        {
            PartnerEnum partnerEnum;
            if (Enum.TryParse(partner, out partnerEnum))
            {
                switch (partnerEnum)
                {
                    case PartnerEnum.A:
                        return new PartnerA();
                    case PartnerEnum.B:
                        return new PartnerB();
                    case PartnerEnum.C:
                        return new PartnerC();
                    case PartnerEnum.D:
                        return new PartnerD();
                }
            }

            throw new Exception("Invalid Partner");
        }
    }
}