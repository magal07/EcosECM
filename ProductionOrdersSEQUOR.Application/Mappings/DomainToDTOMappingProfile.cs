using AutoMapper;
using ProductionOrderSEQUOR.Application.DTOs;
using ProductionOrderSEQUOR.Domain.Entities;

namespace ProductionOrderSEQUOR.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Production, ProductionDTO>().ReverseMap().
                    ForMember(dest => dest.Product, opt => opt.MapFrom(x => x.ProductDTO))
                    .ForMember(dest => dest.User, opt => opt.MapFrom(x => x.UserDTO));
            CreateMap<Production, ProductionPostDTO>().ReverseMap();



            // ACIMA: Mapeamento do Product e User dentro de Produção! 

        }
    }
}
