using System.Text.Json.Serialization;

namespace ContainerAPI.Models
{
    public class Movimentacao
    {
        public int movimentacaoId { get; set; }
        public string? movimentacaoTipo { get; set; }
        public DateTime movimentacaoInicio { get; set; }
        public DateTime movimentacaoFim { get; set; }

        public int containerId { get; set; }

        [JsonIgnore]
        public Container? Container { get; set; }
    }
}
