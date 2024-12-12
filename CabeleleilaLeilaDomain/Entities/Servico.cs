namespace CabeleleilaLeilaDomain.Entities;

public class Servico
{
	public string Id { get; }
	public string Nome { get; private set; }
	public string? Descricao { get; private set; }
	public virtual ICollection<Agendamento>? Agendamentos { get; private set; }

	public Servico(string nome, string? descricao = null)
	{
		Id = Guid.NewGuid().ToString();
		Nome = nome;
		Descricao = descricao;
	}
}
