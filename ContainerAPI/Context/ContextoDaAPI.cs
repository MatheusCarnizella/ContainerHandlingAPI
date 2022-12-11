using ContainerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContainerAPI.Context
{
    public class ContextoDaAPI : DbContext
    {
        public ContextoDaAPI(DbContextOptions options) : base(options)
        {}

        public DbSet<Container>? Containers { get; set; }
        public DbSet<Movimentacao>? Movimentacoes { get; set; }

        protected override void OnModelCreating (ModelBuilder mb)
        {
            mb.Entity<Container>().HasKey(c => c.containerId);
            mb.Entity<Container>().Property(c => c.clienteNome).IsRequired();
            mb.Entity<Container>().Property(c => c.containerNumero).HasMaxLength(11).IsRequired();
            mb.Entity<Container>().Property(c => c.containerTipo).IsRequired();
            mb.Entity<Container>().Property(c => c.containerStatusVazio).IsRequired();
            mb.Entity<Container>().Property(c => c.containerCategoria).IsRequired();

            mb.Entity<Movimentacao>().HasKey(m => m.movimentacaoId);
            mb.Entity<Movimentacao>().Property(m => m.movimentacaoTipo).IsRequired();
            mb.Entity<Movimentacao>().Property(m => m.movimentacaoInicio).IsRequired();
            mb.Entity<Movimentacao>().Property(m => m.movimentacaoFim).IsRequired();

            mb.Entity<Container>()
                .HasMany(m => m.Movimentacao)
                .WithOne(c => c.Container)
                .HasForeignKey(m => m.containerId);

        }
    }
}
