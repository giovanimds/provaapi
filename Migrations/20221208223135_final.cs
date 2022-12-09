using Microsoft.EntityFrameworkCore.Migrations;

namespace AcademiaIMC.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "resultado",
                table: "Imcs",
                newName: "Resultado");

            migrationBuilder.AddColumn<string>(
                name: "Classificacao",
                table: "Imcs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Grau",
                table: "Imcs",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Classificacao",
                table: "Imcs");

            migrationBuilder.DropColumn(
                name: "Grau",
                table: "Imcs");

            migrationBuilder.RenameColumn(
                name: "Resultado",
                table: "Imcs",
                newName: "resultado");
        }
    }
}
