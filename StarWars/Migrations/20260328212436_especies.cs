using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarWars.Migrations
{
    /// <inheritdoc />
    public partial class especies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Especies_Personas_PersonaId",
                table: "Especies");

            migrationBuilder.DropIndex(
                name: "IX_Especies_PersonaId",
                table: "Especies");

            migrationBuilder.DropColumn(
                name: "PersonaId",
                table: "Especies");

            migrationBuilder.AddColumn<string>(
                name: "AlturaPromedio",
                table: "Especies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ColoresDeOjos",
                table: "Especies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ColoresDePelo",
                table: "Especies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ColoresDePiel",
                table: "Especies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Idioma",
                table: "Especies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Especies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Especies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "EspeciePersona",
                columns: table => new
                {
                    EspecieId = table.Column<int>(type: "int", nullable: false),
                    PersonasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspeciePersona", x => new { x.EspecieId, x.PersonasId });
                    table.ForeignKey(
                        name: "FK_EspeciePersona_Especies_EspecieId",
                        column: x => x.EspecieId,
                        principalTable: "Especies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EspeciePersona_Personas_PersonasId",
                        column: x => x.PersonasId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EspeciePersona_PersonasId",
                table: "EspeciePersona",
                column: "PersonasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EspeciePersona");

            migrationBuilder.DropColumn(
                name: "AlturaPromedio",
                table: "Especies");

            migrationBuilder.DropColumn(
                name: "ColoresDeOjos",
                table: "Especies");

            migrationBuilder.DropColumn(
                name: "ColoresDePelo",
                table: "Especies");

            migrationBuilder.DropColumn(
                name: "ColoresDePiel",
                table: "Especies");

            migrationBuilder.DropColumn(
                name: "Idioma",
                table: "Especies");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Especies");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Especies");

            migrationBuilder.AddColumn<int>(
                name: "PersonaId",
                table: "Especies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Especies_PersonaId",
                table: "Especies",
                column: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Especies_Personas_PersonaId",
                table: "Especies",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id");
        }
    }
}
