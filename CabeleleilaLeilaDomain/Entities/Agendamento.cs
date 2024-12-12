namespace CabeleleilaLeilaDomain.Entities;

public class Agendamento
{
	public string Id { get; }
	public string ClienteId { get; }
	public virtual Cliente Cliente { get; } = null!;
	public virtual ICollection<Servico> Servicos { get; private set; } = null!;
	public DateOnly Data { get; private set; }
	public TimeOnly Hora { get; private set; }
	public DateTime? DataCancelado { get; private set; }

	public Agendamento(string id, string clienteId, DateOnly data, TimeOnly hora)
	{
		Id = id;
		ClienteId = clienteId;
		Data = data;
		Hora = hora;
	}

	public Agendamento(Cliente cliente, ICollection<Servico> servicos, DateOnly data, TimeOnly hora) //Requisito 1
	{
		ValidarCriacao(servicos, data, hora);

		Id = Guid.NewGuid().ToString();
		ClienteId = cliente.Id;
		Cliente = cliente;
		Servicos = servicos;
		Data = data;
		Hora = hora;
	}

	private void ValidarCriacao(ICollection<Servico> servicos, DateOnly data, TimeOnly hora)
	{
		ValidarServicos(servicos);
		ValidarDataHora(data, hora);
	}

	public void AlterarAgendamento(Cliente cliente, ICollection<Servico> servicos, DateOnly data, TimeOnly hora) //Requisito 2
	{
		ValidarAlteracao(cliente, servicos, data, hora);

		Servicos = servicos;
		Data = data;
		Hora = hora;
	}

	private void ValidarAlteracao(Cliente cliente, ICollection<Servico> servicos, DateOnly data, TimeOnly hora)
	{
		ValidarCliente(cliente);

		if (IsCancelado()) throw new InvalidOperationException("O Agendamento informado não pode ser alterado pois está cancelado.");

		ValidarPoliticaAlteracao();
		ValidarServicos(servicos);
		ValidarDataHora(data, hora);
	}

	public void CancelarAgendamento(Cliente cliente) //Requisito 2
	{
		ValidarCancelamento(cliente);

		DataCancelado = DateTime.Now;
	}

	private void ValidarCancelamento(Cliente cliente)
	{
		ValidarCliente(cliente);

		if (IsCancelado()) throw new InvalidOperationException("O Agendamento informado já está cancelado.");

		ValidarPoliticaAlteracao();
	}

	private void ValidarServicos(ICollection<Servico> servicos)
	{
		if (servicos.Count == 0) throw new ArgumentException("Nenhum serviço informado.", nameof(servicos));
	}

	private void ValidarDataHora(DateOnly data, TimeOnly hora)
	{
		DateTime now = DateTime.Now;

		if (data < DateOnly.FromDateTime(now)) throw new InvalidOperationException("A data informada é inválida (data passada).");

		if (hora < TimeOnly.FromDateTime(now)) throw new InvalidOperationException("A hora informada é inválida (hora passada).");
	}

	private void ValidarCliente(Cliente cliente)
	{
		if (cliente.Id != ClienteId) throw new InvalidOperationException("O cliente informado não tem permissão para alterar este agendamento.");
	}

	private void ValidarPoliticaAlteracao() //Regra de negócio Requisito 2
	{		
		DateTime dataHoraAgendamento = new(Data, Hora);
		DateTime dataHoraLimite = dataHoraAgendamento.AddDays(-2);

		if (DateTime.Now > dataHoraLimite) throw new InvalidOperationException("Não é permitido alterar o acompanhamento com menos de dois dias para a data previamente selecionada. Entre em contato por telefone para realizar a alteração.");
	}

	private bool IsCancelado()
	{
		return DataCancelado.HasValue;
	}
}
