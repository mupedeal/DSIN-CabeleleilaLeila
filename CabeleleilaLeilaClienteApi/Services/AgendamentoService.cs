using AutoMapper;
using CabeleleilaLeilaClienteDto;
using CabeleleilaLeilaDomain.Entities;
using CabeleleilaLeilaInfra.Repositories;

namespace CabeleleilaLeilaClienteApi.Services;

public class AgendamentoService : IAgendamentoService
{
	private readonly AgendamentoRepository _agendamentoRepo;
	private readonly ClienteRepository _clienteRepo;
	private readonly ServicoRepository _servicoRepo;
	private readonly IMapper _mapper;

	public AgendamentoService(AgendamentoRepository agendamentoRepo, ClienteRepository clienteRepo, ServicoRepository servicoRepo, IMapper mapper)
	{
		_agendamentoRepo = agendamentoRepo;
		_clienteRepo = clienteRepo;
		_servicoRepo = servicoRepo;
		_mapper = mapper;
	}

	public void Add(string clienteId, AgendamentoRequestDto agendamentoRequest)
	{
		Cliente cliente = _clienteRepo.GetById(clienteId) ?? throw new ArgumentException("Cliente informado não encontrado.", nameof(clienteId));
		List<Servico> servicos = [];

		foreach (string servicoId in agendamentoRequest.Servicos.Distinct().ToList())
		{
			Servico servico = _servicoRepo.GetById(servicoId) ?? throw new ArgumentException($"Serviço não encontrado para o Id {servicoId}.", nameof(agendamentoRequest));
			servicos.Add(servico);
		}

		Agendamento agendamento = cliente.AgendarServicos(servicos, agendamentoRequest.Data, agendamentoRequest.Hora);

		_ = _agendamentoRepo.Add(agendamento);
	}

	public void Cancel(string clienteId, string id)
	{
		Agendamento agendamento = _agendamentoRepo.GetById(clienteId, id) ?? throw new ArgumentException("Agendamento não encontrado.", nameof(id));
		Cliente cliente = _clienteRepo.GetById(clienteId) ?? throw new ArgumentException("Cliente informado não encontrado.", nameof(clienteId));

		cliente.CancelarAgendamento(agendamento);

		_ = _agendamentoRepo.Update(agendamento);
	}

	public IEnumerable<AgendamentoResponseDto> GetAll(string clienteId, int limit, int offset)
	{
		IEnumerable<Agendamento> agendamentos = _agendamentoRepo.GetAll(clienteId, limit, offset);

		return _mapper.Map<IEnumerable<Agendamento>, IEnumerable<AgendamentoResponseDto>>(agendamentos);
	}

	public AgendamentoResponseDto GetById(string clienteId, string id)
	{
		Agendamento agendamento = _agendamentoRepo.GetById(clienteId, id) ?? throw new ArgumentException("Agendamento não encontrado.", nameof(id));

		return _mapper.Map<Agendamento, AgendamentoResponseDto>(agendamento);
	}

	public void Update(string clienteId, string id, AgendamentoRequestDto agendamentoRequest)
	{
		Agendamento agendamento = _agendamentoRepo.GetById(clienteId, id) ?? throw new ArgumentException("Agendamento não encontrado.", nameof(id));
		Cliente cliente = _clienteRepo.GetById(clienteId) ?? throw new ArgumentException("Cliente informado não encontrado.", nameof(clienteId));
		List<Servico> servicos = [];

		foreach (string servicoId in agendamentoRequest.Servicos.Distinct().ToList())
		{
			Servico servico = _servicoRepo.GetById(servicoId) ?? throw new ArgumentException($"Serviço não encontrado para o Id {servicoId}.", nameof(agendamentoRequest));
			servicos.Add(servico);
		}

		cliente.AlterarAgendamento(agendamento, servicos, agendamentoRequest.Data, agendamentoRequest.Hora);

		_ = _agendamentoRepo.Update(agendamento);
	}
}
