using CabeleleilaLeilaClienteDto;
using System.Text.Json;

namespace CabeleleilaLeilaCliente.Services;

public class ClienteService : IClienteService
{
	private readonly IHttpClientFactory _httpClientFactory;

	public ClienteService(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
	}

	public async Task<IEnumerable<ServicoResponseDto>?> GetServicosAsync()
	{
		HttpClient client = _httpClientFactory.CreateClient("SignoutWorldApi");
		HttpResponseMessage response = await client.GetAsync("/servico");
		
		response.EnsureSuccessStatusCode();

		string content = await response.Content.ReadAsStringAsync();

		return JsonSerializer.Deserialize<IEnumerable<ServicoResponseDto>>(content);
	}
}
