using System.Text.Json.Serialization;

namespace Container.Application.ItemView;

public sealed class MovimentacaoItemView
{
    public int movimentacaoId { get; set; }
    public string? movimentacaoTipo { get; set; }
    public string? movimentacaoInicio { get; set; }
    public string? movimentacaoFim { get; set; }

    public int containerId { get; set; }

    [JsonIgnore]
    public ContainerItemView? Container { get; set; }
}
