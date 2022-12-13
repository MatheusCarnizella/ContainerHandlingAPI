using AutoMapper;
using Container.Application.ItemView;
using Container.Domain.Entities;
using Container.Domain.Repositories;

namespace Container.API.EndPoints;

public static class RelatorioEndPoint
{
    public static void MapRelatorioEndPoint(this WebApplication ep)
    {
        ep.MapGet("/Relatorio/pegarumRelatorio", async (IRelatorioRepository _repository, IMapper _mapper) =>
        {
            var relatorio = await _repository.GetByMovimentacao();
            var relatorioView = _mapper.Map<List<ContainerItemView>>(relatorio);
            return relatorioView;
        })
        .Produces<List<Containers>>(StatusCodes.Status200OK)
        .WithName("PegarRelatorios")
        .WithTags("Relatorio");
    }
}
