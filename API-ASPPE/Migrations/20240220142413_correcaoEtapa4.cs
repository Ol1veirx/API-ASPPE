using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_ASPPE.Migrations
{
    /// <inheritdoc />
    public partial class correcaoEtapa4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Etapas_Equipes_EquipeId",
                table: "Etapas");

            migrationBuilder.DropIndex(
                name: "IX_Etapas_EquipeId",
                table: "Etapas");

            migrationBuilder.DropColumn(
                name: "EquipeId",
                table: "Etapas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipeId",
                table: "Etapas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Etapas_EquipeId",
                table: "Etapas",
                column: "EquipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Etapas_Equipes_EquipeId",
                table: "Etapas",
                column: "EquipeId",
                principalTable: "Equipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
