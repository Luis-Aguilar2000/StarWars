using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarWars.Migrations
{
    /// <inheritdoc />
    public partial class nueva1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transporte_Personas_PersonaId",
                table: "Transporte");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transporte",
                table: "Transporte");

            migrationBuilder.RenameTable(
                name: "Transporte",
                newName: "planeta");

            migrationBuilder.RenameIndex(
                name: "IX_Transporte_PersonaId",
                table: "planeta",
                newName: "IX_planeta_PersonaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_planeta",
                table: "planeta",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_planeta_Personas_PersonaId",
                table: "planeta",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_planeta_Personas_PersonaId",
                table: "planeta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_planeta",
                table: "planeta");

            migrationBuilder.RenameTable(
                name: "planeta",
                newName: "Transporte");

            migrationBuilder.RenameIndex(
                name: "IX_planeta_PersonaId",
                table: "Transporte",
                newName: "IX_Transporte_PersonaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transporte",
                table: "Transporte",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transporte_Personas_PersonaId",
                table: "Transporte",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id");
        }
    }
}
