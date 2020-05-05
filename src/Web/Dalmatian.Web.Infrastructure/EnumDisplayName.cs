namespace Dalmatian.Web.Infrastructure
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;

    public static partial class EnumDisplayName
    {
        public static string GetEnumDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()?
                .GetMember(enumValue.ToString())
                .First()?
                .GetCustomAttribute<DisplayAttribute>()
                .GetName();
        }
    }
}
