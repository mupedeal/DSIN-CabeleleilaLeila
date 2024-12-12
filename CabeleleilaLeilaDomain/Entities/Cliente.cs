using CabeleleilaLeilaDomain.Types;

namespace CabeleleilaLeilaDomain.Entities;

public class Cliente
{
	public string Id { get; }
	public string Nome { get; private set; }
	public string Cpf { get; private set; }
	public string? Celular { get; private set; }
	public string? Email { get; private set; }
	public virtual ICollection<Agendamento>? Agendamentos { get; private set; }

	public Cliente(string id, string nome, string cpf, string? celular, string? email)
	{
		Id = id;
		Nome = nome;
		Cpf = cpf;
		Celular = celular;
		Email = email;
	}

	public Cliente(string nome, string cpf, CelularType? celular, string? email)
	{
		if (celular == null && string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Nenhum contato (celular ou e-mail) informado.");

		Id = Guid.NewGuid().ToString();
		Nome = nome;
		Cpf = cpf;
		Celular = celular?.Get();
		Email = email;
	}

	public Agendamento AgendarServicos(ICollection<Servico> servicos, DateOnly data, TimeOnly hora)
	{
		Agendamento agendamento = new(this, servicos, data, hora);

		return agendamento;
	}

	public void AlterarAgendamento(Agendamento agendamento, ICollection<Servico> servicos, DateOnly data, TimeOnly hora)
	{
		agendamento.AlterarAgendamento(this, servicos, data, hora);
	}

	public void CancelarAgendamento(Agendamento agendamento)
	{
		agendamento.CancelarAgendamento(this);
	}
}
