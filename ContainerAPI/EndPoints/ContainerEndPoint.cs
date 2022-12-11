using ContainerAPI.Models;
using ContainerAPI.Repositorys;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.CompilerServices;

namespace ContainerAPI.EndPoints;

public static class ContainerEndPoint
{
    public static void MapContainerEndPoint(this WebApplication ep)
    {
        ep.MapPost("/container/cadastrarContainer", async (Container container, IContainerRepository _repository) =>
        {
            await _repository.Post(container);
            return Results.Created($"/cadastrarContainer/{container.containerId}", container);
        })
            .Produces<Container>(StatusCodes.Status201Created)
            .WithName("CriarUmNovoContainer")
            .WithTags("Container");

        ep.MapGet("/container/pegartodosContainer", async (IContainerRepository _repository) =>
        {
            var container = await _repository.GetAll();
            return container;
        })
            .Produces <List<Container>>(StatusCodes.Status200OK)
            .WithName("PegarTodosContainer")
            .WithTags("Container");

        ep.MapGet("/container/pegarpeloIdContainer/{Id:int}", async (int Id, IContainerRepository _repository) =>
        {
            var container = await _repository.GetById(x => x.containerId == Id);               
            return container;
        })
            .Produces <Container>(StatusCodes.Status200OK)
            .Produces<Container>(StatusCodes.Status404NotFound)
            .WithName("PegarContainerPeloId")
            .WithTags("Container");

        ep.MapPut("/container/atualizarContainer/{Id:int}", (int Id, Container container, IContainerRepository _repository) =>
        {
            _repository.Put(container);
            return Results.Ok(container);
        })
            .Produces<Container>(StatusCodes.Status200OK)
            .Produces<Container>(StatusCodes.Status404NotFound)
            .WithName("AtualizarContainer")
            .WithTags("Container");

        ep.MapDelete("/container/deletarContainer/{Id:int}", async (int Id, IContainerRepository _repository) =>
        {
            var delete = await _repository.GetById(x => x.containerId == Id);

            if(delete is null)
            {
                return Results.NotFound("Container não encontrado");
            }

            _repository.Delete(delete);
            return Results.Ok(delete);
        })
            .Produces<Container>(StatusCodes.Status200OK)
            .Produces<Container>(StatusCodes.Status404NotFound)
            .WithName("DeletarContainer")
            .WithTags("Container");
    }
}
