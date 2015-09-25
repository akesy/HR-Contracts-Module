using System;
using HR.Contracts.Shared.Enums;

namespace HR.Contracts.Shared.Extensions
{
    public static class EnumExtensions
    {
        public static string ToLocalizedString(this Enum enumValue)
        {
            return LocalizedEnumConverter.ConvertToString(enumValue);
        }
    }
}