using AutoMapper;
using QuoteFetcher.DTO.MapperExample;

namespace QuoteFetcher.Config;

public static class MappingConfig
{
    public static MapperConfiguration Setup()
    {
       return new MapperConfiguration(
           cfg => cfg.CreateMap<UserInput, UserOutput>()
            .ForMember(d => d.NetSaving,
                s => s.MapFrom(x => x.Income * 0.7 - x.Expense))
            .ForMember(d => d.FullName,
                s => s.MapFrom(x => $"{x.FirstName} {x.LastName}"))
            .ForMember(d => d.Address, s => s.Condition((src, dest, srcMember, destMember) => destMember == null)));
    }
}
