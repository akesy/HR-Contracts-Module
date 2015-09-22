using System.Runtime.Serialization;

namespace HR.Contracts.Services.Dto
{
    [DataContract]
    public class DtoContract
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public ContractType? Type { get; set; }

        [DataMember]
        public int? Experience { get; set; }

        [DataMember]
        public decimal? Salary { get; set; }
    }
}
