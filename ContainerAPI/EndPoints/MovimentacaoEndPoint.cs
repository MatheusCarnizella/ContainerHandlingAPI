using ContainerAPI.Models;
using ContainerAPI.Repositorys;

namespace ContainerAPI.EndPoints;

public static class MovimentacaoEndPoint
{
    public static void MapMovimentacaoEndPoint(this WebApplication ep)
    {
        ep.MapPost("/movimentacao/cadastrarMovimentacao", async (Movimentacao movimentacao, IMovimentacaoRepository _repository) =>
        {
            await _repository.Post(movimentacao);
            return Results.Created($"/cadastrarMovimentacao/{movimentacao.movimentacaoId}", movimentacao);
        })
            .Produces<Movimentacao>(StatusCodes.Status201Created)
            .WithName("CriarUmNovoMovimentacao")
            .WithTags("Movimentacao");

        ep.MapGet("/movimentacao/pegartodosMovimentacao", async (IMovimentacaoRepository _repository) =>
        {
            var movimentacao = await _repository.GetAll();
            return movimentacao;
        })
            .Produces<List<Movimentacao>>(StatusCodes.Status200OK)
            .WithName("PegarTodosMovimentacao")
            .WithTags("Movimentacao");

        ep.MapGet("/movimentacao/pegarpeloIdMovimentacao/{Id:int}", async (int Id, IMovimentacaoRepository _repository) =>
        {
            var movimentacao = await _repository.GetById(x => x.movimentacaoId == Id);
            return movimentacao;
        })
            .Produces<Movimentacao>(StatusCodes.Status200OK)
            .Produces<Movimentacao>(StatusCodes.Status404NotFound)
            .WithName("PegarMovimentacaoPeloId")
            .WithTags("Movimentacao");

        ep.MapPut("/movimentacao/atualizarMovimentacao/{Id:int}", (int Id, Movimentacao movimentacao, IMovimentacaoRepository _repository) =>
        {
            _repository.Put(movimentacao);
            return Results.Ok(movimentacao);
        })
            .Produces<Movimentacao>(StatusCodes.Status200OK)
            .Produces<Movimentacao>(StatusCodes.Status404NotFound)
            .WithName("AtualizarMovimentacao")
            .WithTags("Movimentacao");

        ep.MapDelete("/movimentacao/deletarMovimentacao/{Id:int}", async (int Id, IMovimentacaoRepository _repository) =>
        {
            var delete = await _repository.GetById(x => x.movimentacaoId == Id);

            if (delete is null)
            {
                return Results.NotFound("Movimentacao não encontrado");
            }

            _repository.Delete(delete);
            return Results.Ok(delete);
        })
            .Produces<Movimentacao>(StatusCodes.Status200OK)
            .Produces<Movimentacao>(StatusCodes.Status404NotFound)
            .WithName("DeletarMovimentacao")
            .WithTags("Movimentacao");
    }
}

