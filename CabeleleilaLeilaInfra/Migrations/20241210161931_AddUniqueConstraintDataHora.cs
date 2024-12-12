using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CabeleleilaLeilaInfra.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueConstraintDataHora : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: "449459d5-0096-4106-a79b-ed30977daa90");

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: "6ad9fd36-fed0-4bee-8d93-51963a262fa2");

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: "58255861-3e9a-4b8e-be07-90a10e1f362c");

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: "6a3bc99a-8aff-464b-9e30-e32cfc2df8d4");

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: "80153a70-4ee1-451e-9dc2-acd840004b67");

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: "8c05bc68-237d-4bd7-aebf-5120ad1acb8f");

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: "983d1003-bc80-47d6-8e5f-a14d2e46cc2e");

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: "9905b73d-ddbe-41e7-a3c7-db01b4fcc59e");

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: "a7c557c2-3006-49c1-8e99-511f19587648");

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: "ae4ceb2d-d4d2-4e21-b25f-f6431d8b2a59");

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: "e7fb9eec-fc71-47ff-8af6-344b64b4e5e2");

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: "f17c5703-7e93-41e2-ab3b-2760997cfd4c");

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

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_Data_Hora",
                table: "Agendamentos",
                columns: new[] { "Data", "Hora" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agendamentos_Data_Hora",
                table: "Agendamentos");

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
        }
    }
}
