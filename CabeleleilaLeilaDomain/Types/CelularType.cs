namespace CabeleleilaLeilaDomain.Types;

public class CelularType
{
	public string CodigoPais { get; } = "55";
	public string Ddd { get; }
	public string Numero { get; }

	public CelularType(string? codigoPais, string ddd, string numero)
	{
		CodigoPais = codigoPais ?? CodigoPais;
		Ddd = ddd;
		Numero = numero;
	}

	public string Get()
	{
		return $"+{CodigoPais}{Ddd}{Numero}";
	}
}
