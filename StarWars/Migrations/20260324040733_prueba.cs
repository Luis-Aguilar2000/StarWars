using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarWars.Migrations
{
    /// <inheritdoc />
    public partial class prueba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Altura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Masa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColorDePiel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColorDeOjos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColorDePelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cumpleaños = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clasificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EsperanzaDeVida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Especies_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pelicula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Episode_id = table.Column<int>(type: "int", nullable: false),
                    Avance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Productor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaDeLanzamiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pelicula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pelicula_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transporte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeriodoDeRotación = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeriodoOrbital = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diametro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clima = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gravedad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Terreno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AguaSuperficial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Poblacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transporte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transporte_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transportes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fabricante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitud = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostoEnCreditos = table.Column<int>(type: "int", nullable: false),
                    Velocidad = table.Column<int>(type: "int", nullable: false),
                    Tripulacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pasajeros = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comsumible = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MGLT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Potencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transportes_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TipoTransporte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransporteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTransporte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoTransporte_Transportes_TransporteId",
                        column: x => x.TransporteId,
                        principalTable: "Transportes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Especies_PersonaId",
                table: "Especies",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pelicula_PersonaId",
                table: "Pelicula",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoTransporte_TransporteId",
                table: "TipoTransporte",
                column: "TransporteId");

            migrationBuilder.CreateIndex(
                name: "IX_Transporte_PersonaId",
                table: "Transporte",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transportes_PersonaId",
                table: "Transportes",
                column: "PersonaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Especies");

            migrationBuilder.DropTable(
                name: "Pelicula");

            migrationBuilder.DropTable(
                name: "TipoTransporte");

            migrationBuilder.DropTable(
                name: "Transporte");

            migrationBuilder.DropTable(
                name: "Transportes");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
