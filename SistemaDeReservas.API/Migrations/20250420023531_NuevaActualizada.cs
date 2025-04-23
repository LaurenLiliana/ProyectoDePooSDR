using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeReservas.API.Migrations
{
    public partial class NuevaActualizada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_pagos_reservas_ReservaEntityReservaId",
            //    table: "pagos");

            ////migrationBuilder.DropIndex(
            ////    name: "IX_pagos_ReservaEntityReservaId",
            ////    table: "pagos");

            migrationBuilder.DropColumn(
                name: "ReservaEntityReservaId",
                table: "pagos");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pagos_reservas_reserva_id",
                table: "pagos");

            migrationBuilder.DropIndex(
                name: "IX_pagos_reserva_id",
                table: "pagos");

            migrationBuilder.AddColumn<int>(
                name: "ReservaEntityReservaId",
                table: "pagos",
                type: "INTEGER",
                nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_pagos_ReservaEntityReservaId",
            //    table: "pagos",
            //    column: "ReservaEntityReservaId");

            migrationBuilder.AddForeignKey(
                name: "FK_pagos_reservas_ReservaEntityReservaId",
                table: "pagos",
                column: "ReservaEntityReservaId",
                principalTable: "reservas",
                principalColumn: "reserva_id");
        }
    }
}
