using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeReservas.API.Migrations
{
    /// <inheritdoc />
    public partial class CambiosPago : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pagos_reservas_reserva_id",
                table: "pagos");

            migrationBuilder.DropForeignKey(
                name: "FK_servicio_adicional_reservas_ReservaEntityReservaId",
                table: "servicio_adicional");

            migrationBuilder.DropIndex(
                name: "IX_servicio_adicional_ReservaEntityReservaId",
                table: "servicio_adicional");

            migrationBuilder.DropIndex(
                name: "IX_pagos_reserva_id",
                table: "pagos");

            migrationBuilder.DropColumn(
                name: "ReservaEntityReservaId",
                table: "servicio_adicional");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_pagos_reserva_id",
                table: "pagos",
                column: "reserva_id");

            migrationBuilder.AddForeignKey(
                name: "FK_pagos_reservas_reserva_id",
                table: "pagos",
                column: "reserva_id",
                principalTable: "reservas",
                principalColumn: "reserva_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_servicio_adicional_reservas_ReservaEntityReservaId",
                table: "servicio_adicional",
                column: "ReservaEntityReservaId",
                principalTable: "reservas",
                principalColumn: "reserva_id");
        }
    }
}
