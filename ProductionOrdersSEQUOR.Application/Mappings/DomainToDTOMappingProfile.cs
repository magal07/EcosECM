using AutoMapper;
//using ProductionOrderSEQUOR.Application.DTOs;
// using ProductionOrderSEQUOR.Domain.Entities;

namespace ProductionOrdersSEQUOR.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
