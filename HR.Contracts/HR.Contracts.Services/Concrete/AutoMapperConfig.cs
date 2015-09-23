using AutoMapper;
using HR.Contracts.Domain.Entities;
using HR.Contracts.Services.Dto;

namespace HR.Contracts.Services.Concrete
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<DtoContract, Contract>();
            Mapper.CreateMap<Contract, DtoContract>();
        }
    }
}