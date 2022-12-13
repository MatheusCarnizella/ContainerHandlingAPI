using System.Text.Json.Serialization;

namespace Container.Domain.Entities;

public sealed class Movimentacao
{
    public int movimentacaoId { get; set; }
    public string? movimentacaoTipo { get; set; }
    public DateTime movimentacaoInicio { get; set; }
    public DateTime movimentacaoFim { get; set; }

    public int containerId { get; set; }

    [JsonIgnore]
    public Containers? Container { get; set; }
}
