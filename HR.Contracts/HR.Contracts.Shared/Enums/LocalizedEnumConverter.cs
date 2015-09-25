using System;
using Infralution.Localization;

namespace HR.Contracts.Shared.Enums
{
    public class LocalizedEnumConverter : ResourceEnumConverter
    {
        public LocalizedEnumConverter(Type type)
            : base(type, Resources.Enums.ResourceManager)
        {
        }
    }
}