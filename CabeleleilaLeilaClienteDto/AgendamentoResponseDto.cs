namespace CabeleleilaLeilaClienteDto;

public class AgendamentoResponseDto
{
	public string Id { get; set; } = null!;
	public IEnumerable<ServicoResponseDto> Servicos { get; set; } = [];
	public DateOnly Data { get; set; }
	public TimeOnly Hora { get; set; }
	public DateTime? DataCancelado { get; set; }
}
