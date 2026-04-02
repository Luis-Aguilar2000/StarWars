using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarWars.Migrations
{
    /// <inheritdoc />
    public partial class AgregarTransportes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transportes_TiposTransporte_TipoTransporteId",
                table: "Transportes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TiposTransporte",
                table: "TiposTransporte");

            migrationBuilder.RenameTable(
                name: "TiposTransporte",
                newName: "TipoTransporte");

            migrationBuilder.AddColumn<int>(
                name: "TransporteId",
                table: "Peliculas",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoTransporte",
                table: "TipoTransporte",
                column: "Id");

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
                name: "IX_Peliculas_TransporteId",
                table: "Peliculas",
                column: "TransporteId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaTransporte_TransportesId",
                table: "PersonaTransporte",
                column: "TransportesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Peliculas_Transportes_TransporteId",
                table: "Peliculas",
                column: "TransporteId",
                principalTable: "Transportes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transportes_TipoTransporte_TipoTransporteId",
                table: "Transportes",
                column: "TipoTransporteId",
                principalTable: "TipoTransporte",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Peliculas_Transportes_TransporteId",
                table: "Peliculas");

            migrationBuilder.DropForeignKey(
                name: "FK_Transportes_TipoTransporte_TipoTransporteId",
                table: "Transportes");

            migrationBuilder.DropTable(
                name: "PersonaTransporte");

            migrationBuilder.DropIndex(
                name: "IX_Peliculas_TransporteId",
                table: "Peliculas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoTransporte",
                table: "TipoTransporte");

            migrationBuilder.DropColumn(
                name: "TransporteId",
                table: "Peliculas");

            migrationBuilder.RenameTable(
                name: "TipoTransporte",
                newName: "TiposTransporte");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TiposTransporte",
                table: "TiposTransporte",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transportes_TiposTransporte_TipoTransporteId",
                table: "Transportes",
                column: "TipoTransporteId",
                principalTable: "TiposTransporte",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
