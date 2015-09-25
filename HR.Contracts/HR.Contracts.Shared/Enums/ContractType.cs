using System.ComponentModel;

namespace HR.Contracts.Shared.Enums
{
    [TypeConverter(typeof(LocalizedEnumConverter))]
    public enum ContractType
    {
        Developer,

        Tester
    }
}