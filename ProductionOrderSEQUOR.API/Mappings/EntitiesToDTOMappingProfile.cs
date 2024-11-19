using AutoMapper;
using ProductionOrderSEQUOR.API.DTOs;
using ProductionOrderSEQUOR.API.Models;

namespace ProductionOrderSEQUOR.API.Mappings
{
    public class EntitiesToDTOMappingProfile : Profile
    {
        public EntitiesToDTOMappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
