using Polly;
using Polly.Extensions.Http;

namespace CabeleleilaLeilaCliente;

public static class Configuration
{
	public static IServiceCollection AddSignoutWorldHttpClient(this IServiceCollection services, ConfigurationManager configurationManager)
	{
		services.AddHttpClient("SignoutWorldApi", o =>
		{
			o.BaseAddress = new Uri(configurationManager["SignoutWorldApi:BaseAddress"]!);
		}).SetHandlerLifetime(TimeSpan.FromMinutes(5)).AddPolicyHandler(GetRetryPolicy());

		return services;
	}

	private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
	{
		return HttpPolicyExtensions
			.HandleTransientHttpError()
			.OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
			.WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
	}
}
