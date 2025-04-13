using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeReservas.API.Migrations
{
    /// <inheritdoc />
    public partial class Correcciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookings_clients_cliente_id",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_bookings_habitacion_habitacion_id",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_habitacion_hotels_hotel_id",
                table: "habitacion");

            migrationBuilder.DropForeignKey(
                name: "FK_payments_bookings_reserva_id",
                table: "payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_payments",
                table: "payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_hotels",
                table: "hotels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_habitacion",
                table: "habitacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clients",
                table: "clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bookings",
                table: "bookings");

            migrationBuilder.RenameTable(
                name: "payments",
                newName: "pagos");

            migrationBuilder.RenameTable(
                name: "hotels",
                newName: "hoteles");

            migrationBuilder.RenameTable(
                name: "habitacion",
                newName: "habitaciones");

            migrationBuilder.RenameTable(
                name: "clients",
                newName: "clientes");

            migrationBuilder.RenameTable(
                name: "bookings",
                newName: "reservas");

            migrationBuilder.RenameIndex(
                name: "IX_payments_reserva_id",
                table: "pagos",
                newName: "IX_pagos_reserva_id");

            migrationBuilder.RenameIndex(
                name: "IX_habitacion_hotel_id",
                table: "habitaciones",
                newName: "IX_habitaciones_hotel_id");

            migrationBuilder.RenameIndex(
                name: "IX_bookings_habitacion_id",
                table: "reservas",
                newName: "IX_reservas_habitacion_id");

            migrationBuilder.RenameIndex(
                name: "IX_bookings_cliente_id",
                table: "reservas",
                newName: "IX_reservas_cliente_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pagos",
                table: "pagos",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_hoteles",
                table: "hoteles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_habitaciones",
                table: "habitaciones",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clientes",
                table: "clientes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_reservas",
                table: "reservas",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_habitaciones_hoteles_hotel_id",
                table: "habitaciones",
                column: "hotel_id",
                principalTable: "hoteles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pagos_reservas_reserva_id",
                table: "pagos",
                column: "reserva_id",
                principalTable: "reservas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reservas_clientes_cliente_id",
                table: "reservas",
                column: "cliente_id",
                principalTable: "clientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reservas_habitaciones_habitacion_id",
                table: "reservas",
                column: "habitacion_id",
                principalTable: "habitaciones",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_habitaciones_hoteles_hotel_id",
                table: "habitaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_pagos_reservas_reserva_id",
                table: "pagos");

            migrationBuilder.DropForeignKey(
                name: "FK_reservas_clientes_cliente_id",
                table: "reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_reservas_habitaciones_habitacion_id",
                table: "reservas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reservas",
                table: "reservas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pagos",
                table: "pagos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_hoteles",
                table: "hoteles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_habitaciones",
                table: "habitaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clientes",
                table: "clientes");

            migrationBuilder.RenameTable(
                name: "reservas",
                newName: "bookings");

            migrationBuilder.RenameTable(
                name: "pagos",
                newName: "payments");

            migrationBuilder.RenameTable(
                name: "hoteles",
                newName: "hotels");

            migrationBuilder.RenameTable(
                name: "habitaciones",
                newName: "habitacion");

            migrationBuilder.RenameTable(
                name: "clientes",
                newName: "clients");

            migrationBuilder.RenameIndex(
                name: "IX_reservas_habitacion_id",
                table: "bookings",
                newName: "IX_bookings_habitacion_id");

            migrationBuilder.RenameIndex(
                name: "IX_reservas_cliente_id",
                table: "bookings",
                newName: "IX_bookings_cliente_id");

            migrationBuilder.RenameIndex(
                name: "IX_pagos_reserva_id",
                table: "payments",
                newName: "IX_payments_reserva_id");

            migrationBuilder.RenameIndex(
                name: "IX_habitaciones_hotel_id",
                table: "habitacion",
                newName: "IX_habitacion_hotel_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bookings",
                table: "bookings",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_payments",
                table: "payments",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_hotels",
                table: "hotels",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_habitacion",
                table: "habitacion",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clients",
                table: "clients",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_clients_cliente_id",
                table: "bookings",
                column: "cliente_id",
                principalTable: "clients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_habitacion_habitacion_id",
                table: "bookings",
                column: "habitacion_id",
                principalTable: "habitacion",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_habitacion_hotels_hotel_id",
                table: "habitacion",
                column: "hotel_id",
                principalTable: "hotels",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_payments_bookings_reserva_id",
                table: "payments",
                column: "reserva_id",
                principalTable: "bookings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
