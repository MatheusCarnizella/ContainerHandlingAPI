using Container.API.EndPoints;
using Container.Infrastructure.Context;
using Container.Shared;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure();

var connectionString = builder.Configuration.GetConnectionString("DC");

builder.Services.AddDbContext<ContextoDaAPI>(options =>
    options.UseSqlServer(connectionString, x => x.MigrationsAssembly("Container.API")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapContainerEndPoint();
app.MapMovimentacaoEndPoint();
app.MapRelatorioEndPoint();

app.Run();
