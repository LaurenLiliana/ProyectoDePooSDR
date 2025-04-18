using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeReservas.API.Migrations
{
    /// <inheritdoc />
    public partial class AreggloDeIdsIndividuales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_at",
                table: "servicio_adicional");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "servicio_adicional");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "reservas");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "reservas");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "pagos");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "pagos");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "hoteles");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "hoteles");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "habitaciones");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "habitaciones");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "clientes");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "clientes");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "servicio_adicional",
                newName: "servicio_adicional_id");

            migrationBuilder.RenameColumn(
                name: "FechaInicio",
                table: "reservas",
                newName: "fechaInicio");

            migrationBuilder.RenameColumn(
                name: "FechaFin",
                table: "reservas",
                newName: "fechaFin");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "reservas",
                newName: "reserva_id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "pagos",
                newName: "pago_id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "hoteles",
                newName: "hotel_id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "habitaciones",
                newName: "habitacion_id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "clientes",
                newName: "cliente_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "servicio_adicional_id",
                table: "servicio_adicional",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "fechaInicio",
                table: "reservas",
                newName: "FechaInicio");

            migrationBuilder.RenameColumn(
                name: "fechaFin",
                table: "reservas",
                newName: "FechaFin");

            migrationBuilder.RenameColumn(
                name: "reserva_id",
                table: "reservas",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "pago_id",
                table: "pagos",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "hotel_id",
                table: "hoteles",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "habitacion_id",
                table: "habitaciones",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "cliente_id",
                table: "clientes",
                newName: "id");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "servicio_adicional",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "servicio_adicional",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "reservas",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "reservas",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "pagos",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "pagos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "hoteles",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "hoteles",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "habitaciones",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "habitaciones",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "clientes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "clientes",
                type: "TEXT",
                nullable: true);
        }
    }
}
