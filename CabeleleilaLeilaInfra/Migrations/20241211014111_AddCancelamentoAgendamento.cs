using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CabeleleilaLeilaInfra.Migrations
{
    /// <inheritdoc />
    public partial class AddCancelamentoAgendamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: "28a46966-4a15-4e93-9dc1-ac0c2b4cca2b");

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: "4486f380-52d2-4128-afcd-d9e0b32abf19");

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: "23ba3f0a-3729-4e3c-b371-62d164051319");

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: "2f645263-78bb-4db9-85ef-5d958c0ebf3d");

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: "5fb85b70-982d-4391-9d51-558d000099fb");

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: "6e444c19-44a3-4e5a-bad7-3936d49f49e3");

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: "86c90757-6685-40df-9965-5df8da28da4a");

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: "88ca3a25-0729-466f-b608-b818662d52ed");

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: "9c0cc176-de42-4276-b6cf-2829a25581ff");

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: "c3bb0a22-82d3-48d1-aa18-ff61ade84a28");

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: "d2fe81d7-911f-44f7-8fe2-eb580f7235d3");

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: "e693c0a1-0f03-48bb-a3eb-96d3043eca4f");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCancelado",
                table: "Agendamentos",
                type: "datetime",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Celular", "Cpf", "Email", "Nome" },
                values: new object[,]
                {
                    { "6c029eaa-9659-4c42-947d-928d3298c6c5", "+5563997022482", "280.855.471-04", "monica@turmadamonica.com.br", "Mônica Cristina de Sousa" },
                    { "ffc733f5-9771-4a35-8e06-ae2daa0e3141", "+5547999097515", "958.997.989-04", "magali@turmadamonica.com.br", "Magali Fernandes de Lima" }
                });

            migrationBuilder.InsertData(
                table: "Servicos",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[,]
                {
                    { "17321ef2-d355-4df9-835f-e8d79d0fcb85", null, "Sobrancelha" },
                    { "2ab92d21-0bbd-454f-a653-a1c8f4e95d91", null, "Escova" },
                    { "3a3e4388-17cd-4839-a148-c4d260ac8dee", null, "Mecha/Luzes/Reflexos" },
                    { "55e62c56-f2fd-43e9-84c1-9b6903374ef0", null, "Depilação" },
                    { "96e1e559-43fb-4e41-a663-d8d7cf7fcc3d", null, "Alisamento" },
                    { "a865f204-0a04-49db-b6e0-2d7356159615", null, "Pé e Mão" },
                    { "e68a40f8-f369-484c-bd02-5bc3aaa9d9cd", null, "Corte de Cabelo" },
                    { "e948d655-61f2-4350-89ad-1d9625ef383d", null, "Progressiva" },
                    { "eb83365d-d997-49ae-bc1c-7212e51308bc", null, "Tratamento Capilar" },
                    { "fe382b74-1b8f-4492-a79c-5da3650c7f15", null, "Penteado e Maquiagem" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: "6c029eaa-9659-4c42-947d-928d3298c6c5");

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: "ffc733f5-9771-4a35-8e06-ae2daa0e3141");

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: "17321ef2-d355-4df9-835f-e8d79d0fcb85");

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: "2ab92d21-0bbd-454f-a653-a1c8f4e95d91");

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: "3a3e4388-17cd-4839-a148-c4d260ac8dee");

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: "55e62c56-f2fd-43e9-84c1-9b6903374ef0");

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: "96e1e559-43fb-4e41-a663-d8d7cf7fcc3d");

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: "a865f204-0a04-49db-b6e0-2d7356159615");

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: "e68a40f8-f369-484c-bd02-5bc3aaa9d9cd");

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: "e948d655-61f2-4350-89ad-1d9625ef383d");

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: "eb83365d-d997-49ae-bc1c-7212e51308bc");

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: "fe382b74-1b8f-4492-a79c-5da3650c7f15");

            migrationBuilder.DropColumn(
                name: "DataCancelado",
                table: "Agendamentos");

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Celular", "Cpf", "Email", "Nome" },
                values: new object[,]
                {
                    { "28a46966-4a15-4e93-9dc1-ac0c2b4cca2b", "+5563997022482", "280.855.471-04", "monica@turmadamonica.com.br", "Mônica Cristina de Sousa" },
                    { "4486f380-52d2-4128-afcd-d9e0b32abf19", "+5547999097515", "958.997.989-04", "magali@turmadamonica.com.br", "Magali Fernandes de Lima" }
                });

            migrationBuilder.InsertData(
                table: "Servicos",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[,]
                {
                    { "23ba3f0a-3729-4e3c-b371-62d164051319", null, "Escova" },
                    { "2f645263-78bb-4db9-85ef-5d958c0ebf3d", null, "Tratamento Capilar" },
                    { "5fb85b70-982d-4391-9d51-558d000099fb", null, "Progressiva" },
                    { "6e444c19-44a3-4e5a-bad7-3936d49f49e3", null, "Mecha/Luzes/Reflexos" },
                    { "86c90757-6685-40df-9965-5df8da28da4a", null, "Pé e Mão" },
                    { "88ca3a25-0729-466f-b608-b818662d52ed", null, "Penteado e Maquiagem" },
                    { "9c0cc176-de42-4276-b6cf-2829a25581ff", null, "Corte de Cabelo" },
                    { "c3bb0a22-82d3-48d1-aa18-ff61ade84a28", null, "Depilação" },
                    { "d2fe81d7-911f-44f7-8fe2-eb580f7235d3", null, "Alisamento" },
                    { "e693c0a1-0f03-48bb-a3eb-96d3043eca4f", null, "Sobrancelha" }
                });
        }
    }
}
