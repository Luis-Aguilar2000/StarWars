using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarWars.Migrations
{
    /// <inheritdoc />
    public partial class relacionplanetas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planetas_Personas_PersonaId",
                table: "Planetas");

            migrationBuilder.DropIndex(
                name: "IX_Planetas_PersonaId",
                table: "Planetas");

            migrationBuilder.DropColumn(
                name: "PersonaId",
                table: "Planetas");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Planetas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Planetas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PlanetaId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_PlanetaId",
                table: "Personas",
                column: "PlanetaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Planetas_PlanetaId",
                table: "Personas",
                column: "PlanetaId",
                principalTable: "Planetas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Planetas_PlanetaId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_PlanetaId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Planetas");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Planetas");

            migrationBuilder.DropColumn(
                name: "PlanetaId",
                table: "Personas");

            migrationBuilder.AddColumn<int>(
                name: "PersonaId",
                table: "Planetas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Planetas_PersonaId",
                table: "Planetas",
                column: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Planetas_Personas_PersonaId",
                table: "Planetas",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id");
        }
    }
}
