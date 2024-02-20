using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_ASPPE.Migrations
{
    /// <inheritdoc />
    public partial class EquipeEtapa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquipeEtapa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EquipeId = table.Column<int>(type: "int", nullable: false),
                    EtapaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipeEtapa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipeEtapa_Equipes_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipeEtapa_Etapas_EtapaId",
                        column: x => x.EtapaId,
                        principalTable: "Etapas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Etapas_EquipeId",
                table: "Etapas",
                column: "EquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Etapas_TorneioId",
                table: "Etapas",
                column: "TorneioId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipeEtapa_EquipeId",
                table: "EquipeEtapa",
                column: "EquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipeEtapa_EtapaId",
                table: "EquipeEtapa",
                column: "EtapaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Etapas_Equipes_EquipeId",
                table: "Etapas",
                column: "EquipeId",
                principalTable: "Equipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Etapas_Torneios_TorneioId",
                table: "Etapas",
                column: "TorneioId",
                principalTable: "Torneios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Etapas_Equipes_EquipeId",
                table: "Etapas");

            migrationBuilder.DropForeignKey(
                name: "FK_Etapas_Torneios_TorneioId",
                table: "Etapas");

            migrationBuilder.DropTable(
                name: "EquipeEtapa");

            migrationBuilder.DropIndex(
                name: "IX_Etapas_EquipeId",
                table: "Etapas");

            migrationBuilder.DropIndex(
                name: "IX_Etapas_TorneioId",
                table: "Etapas");
        }
    }
}
