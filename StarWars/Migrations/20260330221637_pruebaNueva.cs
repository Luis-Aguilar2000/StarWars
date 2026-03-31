using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarWars.Migrations
{
    /// <inheritdoc />
    public partial class pruebaNueva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TiposTransporte_Transportes_TransporteId",
                table: "TiposTransporte");

            migrationBuilder.DropTable(
                name: "PersonaTransporte");

            migrationBuilder.DropIndex(
                name: "IX_TiposTransporte_TransporteId",
                table: "TiposTransporte");

            migrationBuilder.DropColumn(
                name: "TransporteId",
                table: "TiposTransporte");

            migrationBuilder.AddColumn<int>(
                name: "TipoTransporteId",
                table: "Transportes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transportes_TipoTransporteId",
                table: "Transportes",
                column: "TipoTransporteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transportes_TiposTransporte_TipoTransporteId",
                table: "Transportes",
                column: "TipoTransporteId",
                principalTable: "TiposTransporte",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transportes_TiposTransporte_TipoTransporteId",
                table: "Transportes");

            migrationBuilder.DropIndex(
                name: "IX_Transportes_TipoTransporteId",
                table: "Transportes");

            migrationBuilder.DropColumn(
                name: "TipoTransporteId",
                table: "Transportes");

            migrationBuilder.AddColumn<int>(
                name: "TransporteId",
                table: "TiposTransporte",
                type: "int",
                nullable: true);

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
                name: "IX_TiposTransporte_TransporteId",
                table: "TiposTransporte",
                column: "TransporteId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaTransporte_TransportesId",
                table: "PersonaTransporte",
                column: "TransportesId");

            migrationBuilder.AddForeignKey(
                name: "FK_TiposTransporte_Transportes_TransporteId",
                table: "TiposTransporte",
                column: "TransporteId",
                principalTable: "Transportes",
                principalColumn: "Id");
        }
    }
}
