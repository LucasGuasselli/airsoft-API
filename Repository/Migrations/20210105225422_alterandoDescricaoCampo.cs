using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class alterandoDescricaoCampo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descrição",
                table: "Campos");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Campos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jogadores_EquipeId",
                table: "Jogadores",
                column: "EquipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogadores_Equipes_EquipeId",
                table: "Jogadores",
                column: "EquipeId",
                principalTable: "Equipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogadores_Equipes_EquipeId",
                table: "Jogadores");

            migrationBuilder.DropIndex(
                name: "IX_Jogadores_EquipeId",
                table: "Jogadores");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Campos");

            migrationBuilder.AddColumn<string>(
                name: "Descrição",
                table: "Campos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
