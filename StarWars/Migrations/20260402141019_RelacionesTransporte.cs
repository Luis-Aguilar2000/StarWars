using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarWars.Migrations
{
    /// <inheritdoc />
    public partial class RelacionesTransporte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Velocidad",
                table: "Transportes");

            migrationBuilder.RenameColumn(
                name: "Potencia",
                table: "Transportes",
                newName: "VelocidadMaximaAtmosfera");

            migrationBuilder.RenameColumn(
                name: "Comsumible",
                table: "Transportes",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "Capacidad",
                table: "Transportes",
                newName: "Consumibles");

            migrationBuilder.AlterColumn<string>(
                name: "CostoEnCreditos",
                table: "Transportes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CapacidadCarga",
                table: "Transportes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Clase",
                table: "Transportes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Transportes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CapacidadCarga",
                table: "Transportes");

            migrationBuilder.DropColumn(
                name: "Clase",
                table: "Transportes");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Transportes");

            migrationBuilder.RenameColumn(
                name: "VelocidadMaximaAtmosfera",
                table: "Transportes",
                newName: "Potencia");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Transportes",
                newName: "Comsumible");

            migrationBuilder.RenameColumn(
                name: "Consumibles",
                table: "Transportes",
                newName: "Capacidad");

            migrationBuilder.AlterColumn<int>(
                name: "CostoEnCreditos",
                table: "Transportes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Velocidad",
                table: "Transportes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
