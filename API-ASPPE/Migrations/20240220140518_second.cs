using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_ASPPE.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Etapas");

            migrationBuilder.DropColumn(
                name: "Pontuacao",
                table: "Etapas");

            migrationBuilder.DropColumn(
                name: "QuantidadePeixe",
                table: "Etapas");

            migrationBuilder.AddColumn<double>(
                name: "Peso",
                table: "EquipeEtapa",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Pontuacao",
                table: "EquipeEtapa",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "QuantidadePeixe",
                table: "EquipeEtapa",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Peso",
                table: "EquipeEtapa");

            migrationBuilder.DropColumn(
                name: "Pontuacao",
                table: "EquipeEtapa");

            migrationBuilder.DropColumn(
                name: "QuantidadePeixe",
                table: "EquipeEtapa");

            migrationBuilder.AddColumn<double>(
                name: "Peso",
                table: "Etapas",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Pontuacao",
                table: "Etapas",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "QuantidadePeixe",
                table: "Etapas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
