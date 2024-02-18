using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_ASPPE.Migrations
{
    /// <inheritdoc />
    public partial class realacaoEquipeTorneio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Etapa",
                table: "Etapa");

            migrationBuilder.RenameTable(
                name: "Etapa",
                newName: "Etapas");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInicio",
                table: "Torneios",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Localizacao",
                table: "Torneios",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "TorneioId",
                table: "Equipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "Pontuacao",
                table: "Etapas",
                type: "double",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "Peso",
                table: "Etapas",
                type: "double",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Etapas",
                table: "Etapas",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Equipes_TorneioId",
                table: "Equipes",
                column: "TorneioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipes_Torneios_TorneioId",
                table: "Equipes",
                column: "TorneioId",
                principalTable: "Torneios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipes_Torneios_TorneioId",
                table: "Equipes");

            migrationBuilder.DropIndex(
                name: "IX_Equipes_TorneioId",
                table: "Equipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Etapas",
                table: "Etapas");

            migrationBuilder.DropColumn(
                name: "DataInicio",
                table: "Torneios");

            migrationBuilder.DropColumn(
                name: "Localizacao",
                table: "Torneios");

            migrationBuilder.DropColumn(
                name: "TorneioId",
                table: "Equipes");

            migrationBuilder.RenameTable(
                name: "Etapas",
                newName: "Etapa");

            migrationBuilder.AlterColumn<decimal>(
                name: "Pontuacao",
                table: "Etapa",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<decimal>(
                name: "Peso",
                table: "Etapa",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Etapa",
                table: "Etapa",
                column: "Id");
        }
    }
}
