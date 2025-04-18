using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeReservas.API.Migrations
{
    /// <inheritdoc />
    public partial class Anidaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservaEntityReservaId",
                table: "servicio_adicional",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_servicio_adicional_ReservaEntityReservaId",
                table: "servicio_adicional",
                column: "ReservaEntityReservaId");

            migrationBuilder.AddForeignKey(
                name: "FK_servicio_adicional_reservas_ReservaEntityReservaId",
                table: "servicio_adicional",
                column: "ReservaEntityReservaId",
                principalTable: "reservas",
                principalColumn: "reserva_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_servicio_adicional_reservas_ReservaEntityReservaId",
                table: "servicio_adicional");

            migrationBuilder.DropIndex(
                name: "IX_servicio_adicional_ReservaEntityReservaId",
                table: "servicio_adicional");

            migrationBuilder.DropColumn(
                name: "ReservaEntityReservaId",
                table: "servicio_adicional");
        }
    }
}
