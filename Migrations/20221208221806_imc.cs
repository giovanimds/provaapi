using Microsoft.EntityFrameworkCore.Migrations;

namespace AcademiaIMC.Migrations
{
    public partial class imc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Imcs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "resultado",
                table: "Imcs",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Imcs_UsuarioId",
                table: "Imcs",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Imcs_Usuarios_UsuarioId",
                table: "Imcs",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imcs_Usuarios_UsuarioId",
                table: "Imcs");

            migrationBuilder.DropIndex(
                name: "IX_Imcs_UsuarioId",
                table: "Imcs");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Imcs");

            migrationBuilder.DropColumn(
                name: "resultado",
                table: "Imcs");
        }
    }
}
