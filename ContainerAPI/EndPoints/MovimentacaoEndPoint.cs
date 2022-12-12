using AutoMapper;
using ContainerAPI.ItemView;
using ContainerAPI.Models;
using ContainerAPI.Repositorys;

namespace ContainerAPI.EndPoints;

public static class MovimentacaoEndPoint
{
    public static void MapMovimentacaoEndPoint(this WebApplication ep)
    {
        ep.MapPost("/movimentacao/cadastrarMovimentacao", async (MovimentacaoItemView movimentacaoitemview, IMovimentacaoRepository _repository, IMapper _mapper) =>
        {
            var movimentacao = _mapper.Map<Movimentacao>(movimentacaoitemview);
            await _repository.Post(movimentacao);

            var movimentacoes = _mapper.Map<MovimentacaoItemView>(movimentacao);

            return Results.Created($"/cadastrarMovimentacao/{movimentacao.movimentacaoId}", movimentacoes);
        })
            .Produces<Movimentacao>(StatusCodes.Status201Created)
            .WithName("CriarUmNovoMovimentacao")
            .WithTags("Movimentacao");

        ep.MapGet("/movimentacao/pegartodosMovimentacao", async (IMovimentacaoRepository _repository, IMapper _mapper) =>
        {
            var movimentacao = await _repository.GetAll();
            var movimentacaoView = _mapper.Map<List<MovimentacaoItemView>>(movimentacao);
            return movimentacaoView;
        })
            .Produces<List<Movimentacao>>(StatusCodes.Status200OK)
            .WithName("PegarTodosMovimentacao")
            .WithTags("Movimentacao");

        ep.MapGet("/movimentacao/pegarpeloIdMovimentacao/{Id:int}", async (int Id, IMovimentacaoRepository _repository, IMapper _mapper) =>
        {
            var movimentacao = await _repository.GetById(x => x.movimentacaoId == Id);
            var movimentacaoView = _mapper.Map<MovimentacaoItemView>(movimentacao);
            return movimentacaoView;
        })
            .Produces<Movimentacao>(StatusCodes.Status200OK)
            .Produces<Movimentacao>(StatusCodes.Status404NotFound)
            .WithName("PegarMovimentacaoPeloId")
            .WithTags("Movimentacao");

        ep.MapPut("/movimentacao/atualizarMovimentacao/{Id:int}", (int Id, MovimentacaoItemView movimentacaoitemview, IMovimentacaoRepository _repository, IMapper _mapper) =>
        {
            var movimentacao = _mapper.Map<Movimentacao>(movimentacaoitemview);
            _repository.Put(movimentacao);
            return Results.Ok(movimentacao);
        })
            .Produces<Movimentacao>(StatusCodes.Status200OK)
            .Produces<Movimentacao>(StatusCodes.Status404NotFound)
            .WithName("AtualizarMovimentacao")
            .WithTags("Movimentacao");

        ep.MapDelete("/movimentacao/deletarMovimentacao/{Id:int}", async (int Id, IMovimentacaoRepository _repository, IMapper _mapper) =>
        {
            var delete = await _repository.GetById(x => x.movimentacaoId == Id);

            if (delete is null)
            {
                return Results.NotFound("Movimentacao não encontrado");
            }

            _repository.Delete(delete);

            var movimentacaoitemview = _mapper.Map<MovimentacaoItemView>(delete);

            return Results.Ok(movimentacaoitemview);
        })
            .Produces<Movimentacao>(StatusCodes.Status200OK)
            .Produces<Movimentacao>(StatusCodes.Status404NotFound)
            .WithName("DeletarMovimentacao")
            .WithTags("Movimentacao");
    }
}

