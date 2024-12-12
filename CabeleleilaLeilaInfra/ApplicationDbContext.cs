using CabeleleilaLeilaDomain.Entities;
using CabeleleilaLeilaDomain.Types;
using Microsoft.EntityFrameworkCore;

namespace CabeleleilaLeilaInfra;

public class ApplicationDbContext : DbContext
{
	private readonly string? _connectionString;

	public ApplicationDbContext()
	{
		_connectionString = Configuration.GetConnectionString();
	}

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{
	}

	public DbSet<Cliente> Clientes { get; set; }
	public DbSet<Servico> Servicos { get; set; }
	public DbSet<Agendamento> Agendamentos { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Cliente>(c =>
		{
			c.HasKey(x => x.Id);
			c.Property(x => x.Id).HasColumnType("varchar(36)");
			c.Property(x => x.Nome).HasColumnType("varchar(255)").IsRequired();
			c.HasIndex(x => x.Cpf).IsUnique();
			c.Property(x => x.Cpf).HasColumnType("varchar(14)").IsRequired();
			c.Property(x => x.Celular).HasColumnType("varchar(14)");
			c.Property(x => x.Email).HasColumnType("varchar(255)");
			c.HasData(
				new Cliente("Mônica Cristina de Sousa", "280.855.471-04", new CelularType(null, "63", "997022482"), "monica@turmadamonica.com.br"),
				new Cliente("Magali Fernandes de Lima", "958.997.989-04", new CelularType(null, "47", "999097515"), "magali@turmadamonica.com.br")
			);
		});

		modelBuilder.Entity<Servico>(s =>
		{
			s.HasKey(x => x.Id);
			s.Property(x => x.Id).HasColumnType("varchar(36)");
			s.Property(x => x.Nome).HasColumnType("varchar(255)").IsRequired();
			s.Property(x => x.Descricao).HasColumnType("varchar(255)");
			s.HasData(
				new Servico("Corte de Cabelo"),
				new Servico("Escova"),
				new Servico("Pé e Mão"),
				new Servico("Tratamento Capilar"),
				new Servico("Alisamento"),
				new Servico("Progressiva"),
				new Servico("Mecha/Luzes/Reflexos"),
				new Servico("Sobrancelha"),
				new Servico("Depilação"),
				new Servico("Penteado e Maquiagem")
			);
		});

		modelBuilder.Entity<Agendamento>(a =>
		{
			a.HasKey(x => x.Id);
			a.Property(x => x.Id).HasColumnType("varchar(36)");
			a.Property(x => x.ClienteId).HasColumnType("varchar(36)").IsRequired();
			a.HasOne(x => x.Cliente).WithMany(c => c.Agendamentos).HasForeignKey(x => x.ClienteId);
			a.HasMany(x => x.Servicos).WithMany(s => s.Agendamentos);
			a.Property(x => x.Data).HasConversion(v => v.ToDateTime(TimeOnly.MinValue), v => DateOnly.FromDateTime(v)).HasColumnType("date").IsRequired();
			a.Property(x => x.Hora).HasConversion(v => v.ToTimeSpan(), v => TimeOnly.FromTimeSpan(v)).HasColumnType("time").IsRequired();
			a.Property(x => x.DataCancelado).HasColumnType("datetime");
			a.HasIndex("Data", "Hora").IsUnique();
		});

		base.OnModelCreating(modelBuilder);
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if (!string.IsNullOrWhiteSpace(_connectionString))
		{
			optionsBuilder.UseSqlServer(_connectionString);
		}

		base.OnConfiguring(optionsBuilder);
	}
}