using Microsoft.EntityFrameworkCore;
using Container.Domain.Entities;
using Container.Infrastructure.EntitiesConfiguration;

namespace Container.Infrastructure.Context;

public class ContextoDaAPI : DbContext
{
    public ContextoDaAPI(DbContextOptions options) : base(options)
    { }

    public DbSet<Containers>? Containers { get; set; }
    public DbSet<Movimentacao>? Movimentacoes { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        base.OnModelCreating(mb);
        mb.ApplyConfiguration(new ContainerConfiguration());
        mb.ApplyConfiguration(new MovimentacaoConfiguration());
    }
}
