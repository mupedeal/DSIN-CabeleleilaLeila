using CabeleleilaLeilaClienteDto;

namespace CabeleleilaLeilaClienteApi.Services;

public interface IServicoService
{
	IEnumerable<ServicoResponseDto> GetAll();
}
