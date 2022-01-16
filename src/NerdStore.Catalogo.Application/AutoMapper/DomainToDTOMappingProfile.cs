using AutoMapper;
using NerdStore.Catalogo.Application.DTO;
using NerdStore.Catalogo.Domain.Entities;

namespace NerdStore.Catalogo.Application.AutoMapper
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Produto, ProdutoDTO>()
                .ForMember(d => d.Altura, opt => opt.MapFrom(source => source.Dimensoes.Altura))
                .ForMember(d => d.Largura, opt => opt.MapFrom(source => source.Dimensoes.Largura))
                .ForMember(d => d.Profundidade, opt => opt.MapFrom(source => source.Dimensoes.Profundidade));
             
            CreateMap<Categoria, CategoriaDTO>();

        }
    }
}
