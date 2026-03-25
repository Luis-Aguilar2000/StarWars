using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarWars.Migrations
{
    /// <inheritdoc />
    public partial class nueva5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transportes_Personas_PersonaId",
                table: "Transportes");

            migrationBuilder.DropIndex(
                name: "IX_Transportes_PersonaId",
                table: "Transportes");

            migrationBuilder.DropColumn(
                name: "PersonaId",
                table: "Transportes");

            migrationBuilder.CreateTable(
                name: "PersonaTransporte",
                columns: table => new
                {
                    PersonasId = table.Column<int>(type: "int", nullable: false),
                    TransportesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaTransporte", x => new { x.PersonasId, x.TransportesId });
                    table.ForeignKey(
                        name: "FK_PersonaTransporte_Personas_PersonasId",
                        column: x => x.PersonasId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonaTransporte_Transportes_TransportesId",
                        column: x => x.TransportesId,
                        principalTable: "Transportes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonaTransporte_TransportesId",
                table: "PersonaTransporte",
                column: "TransportesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonaTransporte");

            migrationBuilder.AddColumn<int>(
                name: "PersonaId",
                table: "Transportes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transportes_PersonaId",
                table: "Transportes",
                column: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transportes_Personas_PersonaId",
                table: "Transportes",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id");
        }
    }
}
