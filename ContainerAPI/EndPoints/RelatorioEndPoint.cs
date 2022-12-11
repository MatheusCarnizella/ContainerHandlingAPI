using ContainerAPI.Models;
using ContainerAPI.Repositorys;

namespace ContainerAPI.EndPoints
{
    public static class RelatorioEndPoint
    {
        public static void MapRelatorioEndPoint(this WebApplication ep)
        {
            ep.MapGet("/Relatorio/pegarumRelatorio", async (IRelatorioRepository _repository) =>
            {
                var relatorio = await _repository.GetByMovimentacao();
                return relatorio;
            })
            .Produces<List<Container>>(StatusCodes.Status200OK)
            .WithName("PegarRelatorios")
            .WithTags("Relatorio");
        }
    }
}
