using CabeleleilaLeilaCliente.Services;
using CabeleleilaLeilaClienteDto;
using Microsoft.AspNetCore.Mvc;

namespace CabeleleilaLeilaCliente.Controllers;

public class HomeAPIController : ControllerBase
{
	private readonly ILogger<HomeAPIController> _logger;
	private readonly IClienteService _service;

	public HomeAPIController(ILogger<HomeAPIController> logger, IClienteService service)
	{
		_logger = logger;
		_service = service;
	}

	[HttpGet]
	public async Task<ActionResult> GetServicosAsync()
	{
		try
		{
			IEnumerable<ServicoResponseDto>? servicos = await _service.GetServicosAsync();

			return Ok(servicos?.OrderBy(s => s.Nome).ToList());
		}
		catch (Exception ex)
		{
			_logger.LogError(ex.Message);

			return BadRequest(ex.Message);
		}
	}
}
