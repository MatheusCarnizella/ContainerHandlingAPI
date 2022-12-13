using AutoMapper;
using Container.Application.ItemView;
using Container.Domain.Entities;
using Container.Domain.Repositories;

namespace Container.API.EndPoints;

public static class ContainerEndPoint
{
    public static void MapContainerEndPoint(this WebApplication ep)
    {
        ep.MapPost("/container/cadastrarContainer", async (ContainerItemView containeritemview, IContainersRepository _repository, IMapper _mapper) =>
        {
            var container = _mapper.Map<Containers>(containeritemview);
            await _repository.Post(container);

            var containers = _mapper.Map<ContainerItemView>(container);

            return Results.Created($"/cadastrarContainer/{container.containerId}", containers);
        })
            .Produces<Containers>(StatusCodes.Status201Created)
        .WithName("CriarUmNovoContainer")
            .WithTags("Container");

        ep.MapGet("/container/pegartodosContainer", async (IContainersRepository _repository, IMapper _mapper) =>
        {
            var container = await _repository.GetAll();
            var containerView = _mapper.Map<List<ContainerItemView>>(container);
            return containerView;
        })
            .Produces<List<Containers>>(StatusCodes.Status200OK)
        .WithName("PegarTodosContainer")
        .WithTags("Container");

        ep.MapGet("/container/pegarpeloIdContainer/{Id:int}", async (int Id, IContainersRepository _repository, IMapper _mapper) =>
        {
            var container = await _repository.GetById(x => x.containerId == Id);
            var containerView = _mapper.Map<ContainerItemView>(container);
            return containerView;
        })
            .Produces<Containers>(StatusCodes.Status200OK)
            .Produces<Containers>(StatusCodes.Status404NotFound)
        .WithName("PegarContainerPeloId")
        .WithTags("Container");

        ep.MapPut("/container/atualizarContainer/{Id:int}", (int Id, ContainerItemView containeritemview, IContainersRepository _repository, IMapper _mapper) =>
        {
            var container = _mapper.Map<Containers>(containeritemview);
            _repository.Put(container);
            return Results.Ok(container);
        })
            .Produces<Containers>(StatusCodes.Status200OK)
            .Produces<Containers>(StatusCodes.Status404NotFound)
        .WithName("AtualizarContainer")
        .WithTags("Container");

        ep.MapDelete("/container/deletarContainer/{Id:int}", async (int Id, IContainersRepository _repository, IMapper _mapper) =>
        {
            var delete = await _repository.GetById(x => x.containerId == Id);

            if (delete is null)
            {
                return Results.NotFound("Container não encontrado");
            }

            _repository.Delete(delete);

            var containeritemview = _mapper.Map<ContainerItemView>(delete);

            return Results.Ok(containeritemview);
        })
            .Produces<Containers>(StatusCodes.Status200OK)
            .Produces<Containers>(StatusCodes.Status404NotFound)
            .WithName("DeletarContainer")
            .WithTags("Container");
    }
}
