using Container.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Container.Infrastructure.EntitiesConfiguration;

internal class MovimentacaoConfiguration : IEntityTypeConfiguration<Movimentacao>
{
    public void Configure(EntityTypeBuilder<Movimentacao> mb)
    {
        mb.HasKey(m => m.movimentacaoId);
        mb.Property(m => m.movimentacaoTipo).IsRequired();
        mb.Property(m => m.movimentacaoInicio).IsRequired();
        mb.Property(m => m.movimentacaoFim).IsRequired();
    }   
}
