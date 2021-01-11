using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class alterandoPartida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Partidas");

            migrationBuilder.DropColumn(
                name: "Periodo",
                table: "Partidas");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Partidas");

            migrationBuilder.DropColumn(
                name: "Restrito",
                table: "Partidas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Partidas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Periodo",
                table: "Partidas",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Preco",
                table: "Partidas",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<bool>(
                name: "Restrito",
                table: "Partidas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
