using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CabeleleilaLeilaInfra.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(255)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(14)", nullable: false),
                    Celular = table.Column<string>(type: "varchar(14)", nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(255)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    ClienteId = table.Column<string>(type: "varchar(36)", nullable: false),
                    Data = table.Column<DateTime>(type: "date", nullable: false),
                    Hora = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgendamentoServico",
                columns: table => new
                {
                    AgendamentosId = table.Column<string>(type: "varchar(36)", nullable: false),
                    ServicosId = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendamentoServico", x => new { x.AgendamentosId, x.ServicosId });
                    table.ForeignKey(
                        name: "FK_AgendamentoServico_Agendamentos_AgendamentosId",
                        column: x => x.AgendamentosId,
                        principalTable: "Agendamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgendamentoServico_Servicos_ServicosId",
                        column: x => x.ServicosId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Celular", "Cpf", "Email", "Nome" },
                values: new object[,]
                {
                    { "449459d5-0096-4106-a79b-ed30977daa90", "+5563997022482", "280.855.471-04", "monica@turmadamonica.com.br", "Mônica Cristina de Sousa" },
                    { "6ad9fd36-fed0-4bee-8d93-51963a262fa2", "+5547999097515", "958.997.989-04", "magali@turmadamonica.com.br", "Magali Fernandes de Lima" }
                });

            migrationBuilder.InsertData(
                table: "Servicos",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[,]
                {
                    { "58255861-3e9a-4b8e-be07-90a10e1f362c", null, "Penteado e Maquiagem" },
                    { "6a3bc99a-8aff-464b-9e30-e32cfc2df8d4", null, "Corte de Cabelo" },
                    { "80153a70-4ee1-451e-9dc2-acd840004b67", null, "Escova" },
                    { "8c05bc68-237d-4bd7-aebf-5120ad1acb8f", null, "Mecha/Luzes/Reflexos" },
                    { "983d1003-bc80-47d6-8e5f-a14d2e46cc2e", null, "Progressiva" },
                    { "9905b73d-ddbe-41e7-a3c7-db01b4fcc59e", null, "Depilação" },
                    { "a7c557c2-3006-49c1-8e99-511f19587648", null, "Sobrancelha" },
                    { "ae4ceb2d-d4d2-4e21-b25f-f6431d8b2a59", null, "Pé e Mão" },
                    { "e7fb9eec-fc71-47ff-8af6-344b64b4e5e2", null, "Alisamento" },
                    { "f17c5703-7e93-41e2-ab3b-2760997cfd4c", null, "Tratamento Capilar" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_ClienteId",
                table: "Agendamentos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentoServico_ServicosId",
                table: "AgendamentoServico",
                column: "ServicosId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Cpf",
                table: "Clientes",
                column: "Cpf",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgendamentoServico");

            migrationBuilder.DropTable(
                name: "Agendamentos");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
