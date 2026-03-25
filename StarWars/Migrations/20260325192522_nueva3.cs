using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarWars.Migrations
{
    /// <inheritdoc />
    public partial class nueva3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pelicula_Personas_PersonaId",
                table: "Pelicula");

            migrationBuilder.DropForeignKey(
                name: "FK_planeta_Personas_PersonaId",
                table: "planeta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_planeta",
                table: "planeta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pelicula",
                table: "Pelicula");

            migrationBuilder.RenameTable(
                name: "planeta",
                newName: "Planetas");

            migrationBuilder.RenameTable(
                name: "Pelicula",
                newName: "Peliculas");

            migrationBuilder.RenameIndex(
                name: "IX_planeta_PersonaId",
                table: "Planetas",
                newName: "IX_Planetas_PersonaId");

            migrationBuilder.RenameIndex(
                name: "IX_Pelicula_PersonaId",
                table: "Peliculas",
                newName: "IX_Peliculas_PersonaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Planetas",
                table: "Planetas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Peliculas",
                table: "Peliculas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Peliculas_Personas_PersonaId",
                table: "Peliculas",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Planetas_Personas_PersonaId",
                table: "Planetas",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Peliculas_Personas_PersonaId",
                table: "Peliculas");

            migrationBuilder.DropForeignKey(
                name: "FK_Planetas_Personas_PersonaId",
                table: "Planetas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Planetas",
                table: "Planetas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Peliculas",
                table: "Peliculas");

            migrationBuilder.RenameTable(
                name: "Planetas",
                newName: "planeta");

            migrationBuilder.RenameTable(
                name: "Peliculas",
                newName: "Pelicula");

            migrationBuilder.RenameIndex(
                name: "IX_Planetas_PersonaId",
                table: "planeta",
                newName: "IX_planeta_PersonaId");

            migrationBuilder.RenameIndex(
                name: "IX_Peliculas_PersonaId",
                table: "Pelicula",
                newName: "IX_Pelicula_PersonaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_planeta",
                table: "planeta",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pelicula",
                table: "Pelicula",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pelicula_Personas_PersonaId",
                table: "Pelicula",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_planeta_Personas_PersonaId",
                table: "planeta",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id");
        }
    }
}
