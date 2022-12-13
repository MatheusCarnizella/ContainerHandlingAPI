using AutoMapper;
using Container.Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Container.Application.Mappings;
using Container.Domain.Repositories.Repositories;

namespace Container.Shared;

public static class IoC
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection Services)
    {       
        Services.AddScoped<IContainersRepository, ContainerRepository>();
        Services.AddScoped<IMovimentacaoRepository, MovimentacaoRepository>();
        Services.AddScoped<IRelatorioRepository, RelatorioRepository>();

        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingResource());
        });

        IMapper mapper = mappingConfig.CreateMapper();
        Services.AddSingleton(mapper);

        return Services;
    }
}
