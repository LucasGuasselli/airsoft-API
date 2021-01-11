using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class alterandoPartida2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Partidas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Periodo",
                table: "Partidas",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Preco",
                table: "Partidas",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<bool>(
                name: "Restrito",
                table: "Partidas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_CampoId",
                table: "Partidas",
                column: "CampoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partidas_Campos_CampoId",
                table: "Partidas",
                column: "CampoId",
                principalTable: "Campos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partidas_Campos_CampoId",
                table: "Partidas");

            migrationBuilder.DropIndex(
                name: "IX_Partidas_CampoId",
                table: "Partidas");

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
    }
}
