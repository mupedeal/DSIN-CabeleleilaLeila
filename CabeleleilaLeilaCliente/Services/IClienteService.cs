using CabeleleilaLeilaClienteDto;

namespace CabeleleilaLeilaCliente.Services;

public interface IClienteService
{
	Task<IEnumerable<ServicoResponseDto>?> GetServicosAsync();
}
