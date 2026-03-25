using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarWars.Migrations
{
    /// <inheritdoc />
    public partial class nueva4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Peliculas_Personas_PersonaId",
                table: "Peliculas");

            migrationBuilder.DropIndex(
                name: "IX_Peliculas_PersonaId",
                table: "Peliculas");

            migrationBuilder.DropColumn(
                name: "PersonaId",
                table: "Peliculas");

            migrationBuilder.CreateTable(
                name: "PeliculaPersona",
                columns: table => new
                {
                    PeliculasId = table.Column<int>(type: "int", nullable: false),
                    PersonasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculaPersona", x => new { x.PeliculasId, x.PersonasId });
                    table.ForeignKey(
                        name: "FK_PeliculaPersona_Peliculas_PeliculasId",
                        column: x => x.PeliculasId,
                        principalTable: "Peliculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeliculaPersona_Personas_PersonasId",
                        column: x => x.PersonasId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaPersona_PersonasId",
                table: "PeliculaPersona",
                column: "PersonasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeliculaPersona");

            migrationBuilder.AddColumn<int>(
                name: "PersonaId",
                table: "Peliculas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Peliculas_PersonaId",
                table: "Peliculas",
                column: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Peliculas_Personas_PersonaId",
                table: "Peliculas",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id");
        }
    }
}
