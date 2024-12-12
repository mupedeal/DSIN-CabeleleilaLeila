namespace CabeleleilaLeilaClienteDto;

public class AgendamentoRequestDto
{
	public IEnumerable<string> Servicos { get; set; } = [];
	public DateOnly Data { get; set; }
	public TimeOnly Hora { get; set; }
}
