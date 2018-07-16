﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Spotzer.Helper
{
    public class EnumHelper
    {
        public enum PartnerEnum
        {
            A,
            B,
            C,
            D
        };


        public enum ProductTypeEnum
        {
            [Description("Website")]
            Website,
            [Description("Paid Search")]
            PaidSearch
        }
    }

    public static class EnumExtensions
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum value)
            where TAttribute : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);

            return type.GetField(name).GetCustomAttributes(false).OfType<TAttribute>().SingleOrDefault();
        }

        public static String GetDescription(this Enum value)
        {
            var description = GetAttribute<DescriptionAttribute>(value);
            return description != null ? description.Description : null;
        }
    }
}