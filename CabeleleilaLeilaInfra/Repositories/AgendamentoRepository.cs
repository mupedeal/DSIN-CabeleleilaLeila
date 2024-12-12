using CabeleleilaLeilaDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CabeleleilaLeilaInfra.Repositories;

public class AgendamentoRepository
{
	private readonly ApplicationDbContext _context;

	public AgendamentoRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public ICollection<Agendamento> GetAll(string clienteId, int limit, int offset)
	{
		return _context.Agendamentos
			.Where(a => a.ClienteId == clienteId)
			.OrderByDescending(a => a.Data)
			.ThenByDescending(a => a.Hora)
			.Skip(offset)
			.Take(limit)
			.ToList();
	}

	public Agendamento? GetById(string clienteId, string id)
	{
		return _context.Agendamentos
			.Where(a => a.Id == id && a.ClienteId == clienteId)
			.Include(a => a.Servicos)
			.FirstOrDefault();
	}

	public int Add(Agendamento agendamento)
	{
		_ = _context.Agendamentos.Add(agendamento);
		return _context.SaveChanges();
	}

	public int Update(Agendamento agendamento)
	{
		_ = _context.Agendamentos.Update(agendamento);
		return _context.SaveChanges();
	}
}
