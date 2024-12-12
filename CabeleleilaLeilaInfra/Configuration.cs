using CabeleleilaLeilaInfra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CabeleleilaLeilaInfra;

public static class Configuration
{
	public static IServiceCollection AddInfra(this IServiceCollection services)
	{
		services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(GetConnectionString()));
		services.AddMemoryCache();
		services.TryAddTransient<AgendamentoRepository>();
		services.TryAddTransient<ClienteRepository>();
		services.TryAddTransient<ServicoRepository>();

		return services;
	}

	internal static string GetConnectionString()
	{
		return "Data Source=.;Initial Catalog=CabeleleilaLeila;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
	}
}
