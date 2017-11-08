using System;
using System.ComponentModel;
using System.Linq;

namespace Monsters.Common
{
    public static class Extensions
    {
        public static string GetDescription(this Enum enumVal)
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false).Cast<DescriptionAttribute>().ToList();

            return attributes.First().Description;
        }
    }
}