namespace Container.Domain.Entities;

public sealed class Containers
{
    public int containerId { get; set; }
    public string? clienteNome { get; set; }
    public string? containerNumero { get; set; }
    public string? containerTipo { get; } = "20/40";
    public bool containerStatusVazio { get; set; }
    public string? containerCategoria { get; set; }

    public ICollection<Movimentacao>? Movimentacao { get; set; }
}
