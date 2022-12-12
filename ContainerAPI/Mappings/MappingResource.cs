using AutoMapper;
using ContainerAPI.ItemView;
using ContainerAPI.Models;

namespace ContainerAPI.Mappings;

public class MappingResource : Profile
{
    public MappingResource()
    {
        CreateMap<Container, ContainerItemView>()
            .ReverseMap();

        CreateMap<Movimentacao, MovimentacaoItemView>()
            .ForMember(m => m.movimentacaoInicio, m => m.MapFrom((src, m) =>
            {
                var date = (DateTime)src.movimentacaoInicio;
                return date.ToString();
            }))
            .ForMember(m => m.movimentacaoFim, m => m.MapFrom((src, m) =>
            {
                var date = (DateTime)src.movimentacaoFim;
                return date.ToString();
            }))
            .ReverseMap();
    } 
}
