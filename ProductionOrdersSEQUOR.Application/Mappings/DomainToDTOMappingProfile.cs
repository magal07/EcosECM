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
            CreateMap<ProductionDTO, Production>().ReverseMap().
                    ForMember(dest => dest.ProductDTO, opt => opt.MapFrom(x => x.Product))
                    .ForMember(dest => dest.UserDTO, opt => opt.MapFrom(x => x.User));
            CreateMap<Production, ProductionPostDTO>().ReverseMap();


            // Filtro de horário
              /*  CreateMap<ProductionPostDTO, Production>()
                    .ForMember(dest => dest.DateEnd, opt => opt.MapFrom(src => src.DateEnd)); // Mapeia TimeSpan corretamente
            CreateMap<Production, ProductionDTO>();
            */
        }




        // ACIMA: Mapeamento do Product e User dentro de Produção! 

    }
}

