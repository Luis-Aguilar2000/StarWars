using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarWars.Migrations
{
    /// <inheritdoc />
    public partial class cumple : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoTransporte_Transportes_TransporteId",
                table: "TipoTransporte");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoTransporte",
                table: "TipoTransporte");

            migrationBuilder.RenameTable(
                name: "TipoTransporte",
                newName: "TiposTransporte");

            migrationBuilder.RenameIndex(
                name: "IX_TipoTransporte_TransporteId",
                table: "TiposTransporte",
                newName: "IX_TiposTransporte_TransporteId");

            migrationBuilder.AlterColumn<string>(
                name: "Cumpleaños",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TiposTransporte",
                table: "TiposTransporte",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TiposTransporte_Transportes_TransporteId",
                table: "TiposTransporte",
                column: "TransporteId",
                principalTable: "Transportes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TiposTransporte_Transportes_TransporteId",
                table: "TiposTransporte");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TiposTransporte",
                table: "TiposTransporte");

            migrationBuilder.RenameTable(
                name: "TiposTransporte",
                newName: "TipoTransporte");

            migrationBuilder.RenameIndex(
                name: "IX_TiposTransporte_TransporteId",
                table: "TipoTransporte",
                newName: "IX_TipoTransporte_TransporteId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Cumpleaños",
                table: "Personas",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoTransporte",
                table: "TipoTransporte",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoTransporte_Transportes_TransporteId",
                table: "TipoTransporte",
                column: "TransporteId",
                principalTable: "Transportes",
                principalColumn: "Id");
        }
    }
}
