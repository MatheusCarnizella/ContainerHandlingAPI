namespace Container.Application.ItemView;

public sealed class ContainerItemView
{
    public int containerId { get; set; }
    public string? clienteNome { get; set; }
    public string? containerNumero { get; set; }
    public string? containerTipo { get; } = "20/40";
    public string? containerStatusVazio { get; set; }
    public string? containerCategoria { get; set; }

    public ICollection<MovimentacaoItemView>? Movimentacao { get; set; }
}
