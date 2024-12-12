using CabeleleilaLeilaClienteDto;

namespace CabeleleilaLeilaClienteApi.Services;

public interface IAgendamentoService
{
	void Add(string clienteId, AgendamentoRequestDto agendamentoRequest);
	void Cancel(string clienteId, string id);
	IEnumerable<AgendamentoResponseDto> GetAll(string clienteId, int limit, int offset);
	AgendamentoResponseDto GetById(string clienteId, string id);
	void Update(string clienteId, string id, AgendamentoRequestDto agendamentoRequest);
}
