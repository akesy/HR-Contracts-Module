using AutoMapper;
using HR.Contracts.WebUI.ContractService;
using HR.Contracts.WebUI.Models;

namespace HR.Contracts.WebUI.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<DtoContract, ContractModel>();
            Mapper.CreateMap<ContractModel, DtoContract>();
        }
    }
}