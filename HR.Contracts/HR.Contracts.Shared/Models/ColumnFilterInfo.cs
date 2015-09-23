using HR.Contracts.Shared.Enums;

namespace HR.Contracts.Shared.Models
{
    public class ColumnFilterInfo
    {
        public ColumnFilterType Type { get; set; }

        public object Value { get; set; }
    }
}