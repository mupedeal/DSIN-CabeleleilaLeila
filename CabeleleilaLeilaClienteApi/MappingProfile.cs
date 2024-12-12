using AutoMapper;
using CabeleleilaLeilaClienteDto;
using CabeleleilaLeilaDomain.Entities;

namespace CabeleleilaLeilaClienteApi;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<Servico, ServicoResponseDto>();
		CreateMap<Agendamento, AgendamentoResponseDto>();
	}
}
