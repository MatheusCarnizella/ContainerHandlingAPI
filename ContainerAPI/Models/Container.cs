using System.Text.Json.Serialization;

namespace ContainerAPI.Models;

public class Container
{
    public int containerId { get; set; }
    public string? clienteNome { get; set; }
    public string? containerNumero { get; set; }
    public string? containerTipo { get; } = "20/40";
    public bool containerStatusVazio { get; set; }
    public string? containerCategoria { get; set; }

    [JsonIgnore]
    public int movimentacaoId { get; set; }

    public ICollection<Movimentacao>? Movimentacao { get; set; }
}
