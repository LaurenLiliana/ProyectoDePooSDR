using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeReservas.API.Migrations
{
    /// <inheritdoc />
    public partial class UltimasActualizaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pagos_reservas_reserva_id",
                table: "pagos");

            migrationBuilder.DropForeignKey(
                name: "FK_servicio_adicional_reservas_reserva_id",
                table: "servicio_adicional");

            //migrationBuilder.DropIndex(
            //    name: "IX_servicio_adicional_reserva_id",
            //    table: "servicio_adicional");

            //migrationBuilder.DropIndex(
            //    name: "IX_pagos_reserva_id",
            //    table: "pagos");

            migrationBuilder.DropColumn(
                name: "reserva_id",
                table: "servicio_adicional");

            migrationBuilder.DropColumn(
                name: "reserva_id",
                table: "pagos");

            migrationBuilder.AddColumn<int>(
                name: "ReservaEntityReservaId",
                table: "servicio_adicional",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservaEntityReservaId",
                table: "pagos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "notificaciones",
                columns: table => new
                {
                    notificacion_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    titulo = table.Column<string>(type: "TEXT", nullable: false),
                    mensaje = table.Column<string>(type: "TEXT", nullable: false),
                    fecha_envio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    destinatario = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notificaciones", x => x.notificacion_id);
                });

            migrationBuilder.CreateTable(
                name: "ReservasCanceladas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    cliente_id = table.Column<int>(type: "INTEGER", nullable: false),
                    habitacion_id = table.Column<int>(type: "INTEGER", nullable: false),
                    fecha_inicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    fecha_fin = table.Column<DateTime>(type: "TEXT", nullable: false),
                    estado = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservasCanceladas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservasCanceladas_clientes_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "clientes",
                        principalColumn: "cliente_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservasCanceladas_habitaciones_habitacion_id",
                        column: x => x.habitacion_id,
                        principalTable: "habitaciones",
                        principalColumn: "habitacion_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_servicio_adicional_ReservaEntityReservaId",
                table: "servicio_adicional",
                column: "ReservaEntityReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_pagos_ReservaEntityReservaId",
                table: "pagos",
                column: "ReservaEntityReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservasCanceladas_cliente_id",
                table: "ReservasCanceladas",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReservasCanceladas_habitacion_id",
                table: "ReservasCanceladas",
                column: "habitacion_id");

            migrationBuilder.AddForeignKey(
                name: "FK_pagos_reservas_ReservaEntityReservaId",
                table: "pagos",
                column: "ReservaEntityReservaId",
                principalTable: "reservas",
                principalColumn: "reserva_id");

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
                name: "FK_pagos_reservas_ReservaEntityReservaId",
                table: "pagos");

            migrationBuilder.DropForeignKey(
                name: "FK_servicio_adicional_reservas_ReservaEntityReservaId",
                table: "servicio_adicional");

            migrationBuilder.DropTable(
                name: "notificaciones");

            migrationBuilder.DropTable(
                name: "ReservasCanceladas");

            migrationBuilder.DropIndex(
                name: "IX_servicio_adicional_ReservaEntityReservaId",
                table: "servicio_adicional");

            migrationBuilder.DropIndex(
                name: "IX_pagos_ReservaEntityReservaId",
                table: "pagos");

            migrationBuilder.DropColumn(
                name: "ReservaEntityReservaId",
                table: "servicio_adicional");

            migrationBuilder.DropColumn(
                name: "ReservaEntityReservaId",
                table: "pagos");

            migrationBuilder.AddColumn<int>(
                name: "reserva_id",
                table: "servicio_adicional",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "reserva_id",
                table: "pagos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_servicio_adicional_reserva_id",
                table: "servicio_adicional",
                column: "reserva_id");

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
                name: "FK_servicio_adicional_reservas_reserva_id",
                table: "servicio_adicional",
                column: "reserva_id",
                principalTable: "reservas",
                principalColumn: "reserva_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
