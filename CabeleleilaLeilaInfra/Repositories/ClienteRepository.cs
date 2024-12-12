using CabeleleilaLeilaDomain.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace CabeleleilaLeilaInfra.Repositories;

public class ClienteRepository
{
	private readonly ApplicationDbContext _context;
	private readonly IMemoryCache _cache;

	public ClienteRepository(ApplicationDbContext context, IMemoryCache cache)
	{
		_context = context;
		_cache = cache;
	}

	public Cliente? GetById(string id)
	{
		string cacheKey = $"{CacheKeys.CLIENTE}_{id}";

		if (!_cache.TryGetValue(cacheKey, out Cliente? cliente))
		{
			MemoryCacheEntryOptions cacheEntryOptions = new MemoryCacheEntryOptions()
			.SetAbsoluteExpiration(TimeSpan.FromMinutes(10));
			cliente = _context.Clientes.Where(c => c.Id == id).FirstOrDefault();

			if (cliente != null) _cache.Set(cacheKey, cliente, cacheEntryOptions);
		}

		return cliente;
	}
}
