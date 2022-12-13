using Container.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Container.Infrastructure.EntitiesConfiguration;

internal class ContainerConfiguration : IEntityTypeConfiguration<Containers>
{
    public void Configure(EntityTypeBuilder<Containers> mb)
    {
        mb.HasKey(c => c.containerId);
        mb.Property(c => c.clienteNome).IsRequired();
        mb.Property(c => c.containerNumero).HasMaxLength(11).IsRequired();
        mb.Property(c => c.containerTipo).IsRequired();
        mb.Property(c => c.containerStatusVazio).IsRequired();
        mb.Property(c => c.containerCategoria).IsRequired();

        mb.HasMany(m => m.Movimentacao)
        .WithOne(c => c.Container)
        .HasForeignKey(m => m.containerId);
    }
}
