using CabeleleilaLeilaClienteApi.Services;
using CabeleleilaLeilaClienteDto;
using Microsoft.AspNetCore.Mvc;

namespace CabeleleilaLeilaClienteApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ServicoController : ControllerBase
{
	private readonly ILogger<ServicoController> _logger;
	private readonly IServicoService _service;

	public ServicoController(ILogger<ServicoController> logger, IServicoService service)
	{
		_logger = logger;
		_service = service;
	}

	[HttpGet]
	public ActionResult<IEnumerable<ServicoResponseDto>> GetAll()
	{
		try
		{
			IEnumerable<ServicoResponseDto> servicos = _service.GetAll();

			return Ok(servicos);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, ex.Message);

			return BadRequest("Ops! Não foi possível atender a requisição no momento. Tente novamente em alguns minutos e entre em contato com o administrador do sistema caso o erro persista.");
		}
	}
}
