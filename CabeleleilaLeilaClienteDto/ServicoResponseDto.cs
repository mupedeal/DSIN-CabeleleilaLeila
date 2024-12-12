using System.Text.Json.Serialization;

namespace CabeleleilaLeilaClienteDto;

public class ServicoResponseDto
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = null!;
	[JsonPropertyName("nome")]
	public string Nome { get; set; } = null!;
	[JsonPropertyName("descricao")]
	public string? Descricao { get; set; }
}
