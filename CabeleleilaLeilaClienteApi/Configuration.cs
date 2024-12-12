using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace CabeleleilaLeilaClienteApi;

public static class Configuration
{
	public static IServiceCollection AddBearerAuthentication(this IServiceCollection services, ConfigurationManager configurationManager)
	{
		services.AddAuthentication(o =>
		{
			o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		}).AddJwtBearer(o =>
		{
			o.RequireHttpsMetadata = false;
			o.SaveToken = true;
			o.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidateAudience = false,
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true,
				ValidIssuer = configurationManager["Jwt:Issuer"],
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurationManager["Jwt:Key"]!))
			};
		});

		return services;
	}

	public static IServiceCollection AddBearerAuthenticationDoc(this IServiceCollection services)
	{
		services.AddSwaggerGen(o =>
		{
			o.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
			{
				In = ParameterLocation.Header,
				Description = "Por favor, insira 'Bearer' [espaço] e o token JWT",
				Name = "Authorization",
				Type = SecuritySchemeType.ApiKey
			});

			o.AddSecurityRequirement(new OpenApiSecurityRequirement
			{
				{
					new OpenApiSecurityScheme
					{
						Reference = new OpenApiReference
						{
							Type = ReferenceType.SecurityScheme,
							Id = "Bearer"
						}
					},
					new string[] { }
				}
			});
		});

		return services;
	}
}
