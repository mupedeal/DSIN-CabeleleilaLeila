using CabeleleilaLeilaClienteApi.Services;
using CabeleleilaLeilaClienteDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CabeleleilaLeilaClienteApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class AgendamentoController : ControllerBase
{
	private readonly ILogger<AgendamentoController> _logger;
	private readonly IAgendamentoService _service;
	private readonly string _clienteId = "6c029eaa-9659-4c42-947d-928d3298c6c5";

	public AgendamentoController(ILogger<AgendamentoController> logger, IAgendamentoService service)
	{
		_logger = logger;
		_service = service;
	}

	[HttpGet]
	public ActionResult<IEnumerable<AgendamentoResponseDto>> GetAll(int limit = 10, int offset = 0) //Requisito 3
	{
		try
		{
			string clienteId = _clienteId;
			IEnumerable<AgendamentoResponseDto> agendamentos = _service.GetAll(clienteId, limit, offset);

			return Ok(agendamentos);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, ex.Message);

			return BadRequest("Ops! Não foi possível atender a requisição no momento. Tente novamente em alguns minutos e entre em contato com o administrador do sistema caso o erro persista.");
		}
	}

	[HttpGet]
	[Route("{id}")]
	public ActionResult<AgendamentoResponseDto> GetById(string id) //Requisito 4
	{
		try
		{
			string clienteId = _clienteId;
			AgendamentoResponseDto agendamento = _service.GetById(clienteId, id);

			return Ok(agendamento);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, ex.Message);

			return BadRequest("Ops! Não foi possível atender a requisição no momento. Tente novamente em alguns minutos e entre em contato com o administrador do sistema caso o erro persista.");
		}
	}

	[HttpPost]
	public ActionResult Add([FromBody] AgendamentoRequestDto agendamento) //Requisito 1
	{
		try
		{
			string clienteId = _clienteId;
			_service.Add(clienteId, agendamento);

			return Created();
		}
		catch (Exception ex)
		{
			string exceptionMessage = "Ops! Não foi possível atender a requisição no momento. Tente novamente em alguns minutos e entre em contato com o administrador do sistema caso o erro persista.";

			if (ex is ArgumentException || ex is InvalidOperationException) exceptionMessage = ex.Message;
			else _logger.LogError(ex, ex.Message);

			return BadRequest(exceptionMessage);
		}
	}

	[HttpPut]
	[Route("{id}")]
	public ActionResult Update(string id, [FromBody] AgendamentoRequestDto agendamento) //Requisito 2
	{
		try
		{
			string clienteId = _clienteId;
			_service.Update(clienteId, id, agendamento);

			return NoContent();
		}
		catch (Exception ex)
		{
			string exceptionMessage = "Ops! Não foi possível atender a requisição no momento. Tente novamente em alguns minutos e entre em contato com o administrador do sistema caso o erro persista.";

			if (ex is ArgumentException || ex is InvalidOperationException || ex is ArgumentNullException) exceptionMessage = ex.Message;
			else _logger.LogError(ex, ex.Message);

			return BadRequest(exceptionMessage);
		}
	}

	[HttpDelete]
	[Route("{id}")]
	public ActionResult Delete(string id) //Requisito 2
	{
		try
		{
			string clienteId = _clienteId;
			_service.Cancel(clienteId, id);

			return NoContent();
		}
		catch (Exception ex)
		{
			string exceptionMessage = "Ops! Não foi possível atender a requisição no momento. Tente novamente em alguns minutos e entre em contato com o administrador do sistema caso o erro persista.";

			if (ex is ArgumentException || ex is InvalidOperationException || ex is ArgumentNullException) exceptionMessage = ex.Message;
			else _logger.LogError(ex, ex.Message);

			return BadRequest(exceptionMessage);
		}
	}
}
