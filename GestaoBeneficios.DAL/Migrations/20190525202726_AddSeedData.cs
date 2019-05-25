using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoBeneficios.DAL.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "Perfis",
                columns: new[] { "Id", "Tipo" },
                values: new object[] { 1L, "Administrador" });

            migrationBuilder.InsertData(
                table: "Perfis",
                columns: new[] { "Id", "Tipo" },
                values: new object[] { 2L, "Colaborador" });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Perfis",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Perfis",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
