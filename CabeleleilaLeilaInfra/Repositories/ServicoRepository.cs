using CabeleleilaLeilaDomain.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace CabeleleilaLeilaInfra.Repositories;

public class ServicoRepository
{
	private readonly ApplicationDbContext _context;
	private readonly IMemoryCache _cache;

	public ServicoRepository(ApplicationDbContext context, IMemoryCache cache)
	{
		_context = context;
		_cache = cache;
	}

	public ICollection<Servico> GetAll()
	{
		if (!_cache.TryGetValue(CacheKeys.SERVICOS, out ICollection<Servico>? servicos))
		{
			MemoryCacheEntryOptions cacheEntryOptions = new MemoryCacheEntryOptions()
			.SetAbsoluteExpiration(TimeSpan.FromHours(10));
			servicos = _context.Servicos.ToList();

			_cache.Set(CacheKeys.SERVICOS, servicos, cacheEntryOptions);			
		}

		return servicos!;
	}

	public Servico? GetById(string id)
	{
		if (_cache.TryGetValue(CacheKeys.SERVICOS, out ICollection<Servico>? servicos))
		{
			return servicos?.Where(s => s.Id == id).FirstOrDefault();
		}

		return _context.Servicos.Where(s => s.Id == id).FirstOrDefault();
	}
}
