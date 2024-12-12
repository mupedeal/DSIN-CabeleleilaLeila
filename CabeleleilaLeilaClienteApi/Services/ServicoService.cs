using AutoMapper;
using CabeleleilaLeilaClienteDto;
using CabeleleilaLeilaDomain.Entities;
using CabeleleilaLeilaInfra.Repositories;

namespace CabeleleilaLeilaClienteApi.Services;

public class ServicoService : IServicoService
{
	private readonly ServicoRepository _servicoRepo;
	private readonly IMapper _mapper;

	public ServicoService(ServicoRepository servicoRepo, IMapper mapper)
	{
		_servicoRepo = servicoRepo;
		_mapper = mapper;
	}

	public IEnumerable<ServicoResponseDto> GetAll()
	{
		IEnumerable<Servico> servicos = _servicoRepo.GetAll();

		return _mapper.Map<IEnumerable<Servico>, IEnumerable<ServicoResponseDto>>(servicos);
	}
}
