using CabeleleilaLeilaClienteApi;
using CabeleleilaLeilaClienteApi.Services;
using CabeleleilaLeilaInfra;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfra();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.TryAddTransient<IAgendamentoService, AgendamentoService>();
builder.Services.TryAddTransient<IServicoService, ServicoService>();
builder.Services.AddBearerAuthentication(builder.Configuration).AddBearerAuthenticationDoc();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthorization();

app.MapControllers();

app.Run();
