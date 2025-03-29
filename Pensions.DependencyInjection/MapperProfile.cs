using AutoMapper;
using Pensions.Core.Models;

namespace Pensions.DependencyInjection
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Persistence.Entities.Address, Address>();
            CreateMap<Address, Persistence.Entities.Address>();
            CreateMap<Persistence.Entities.Basic, Basic>();
            CreateMap<Persistence.Entities.Salary, Salary>();
            CreateMap<Persistence.Entities.Service, Service>();
            CreateMap<Persistence.Entities.Results, Results>();
        }
    }
}
