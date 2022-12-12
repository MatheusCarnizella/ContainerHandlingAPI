using AutoMapper;
using ContainerAPI.Context;
using ContainerAPI.EndPoints;
using ContainerAPI.Mappings;
using ContainerAPI.Repositorys;
using ContainerAPI.Repositorys.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DC");

builder.Services.AddDbContext<ContextoDaAPI>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IContainerRepository, ContainerRepository>();
builder.Services.AddScoped<IMovimentacaoRepository, MovimentacaoRepository>();
builder.Services.AddScoped<IRelatorioRepository, RelatorioRepository>();

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingResource());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapContainerEndPoint();
app.MapMovimentacaoEndPoint();
app.MapRelatorioEndPoint();

app.UseHttpsRedirection();

app.Run();

