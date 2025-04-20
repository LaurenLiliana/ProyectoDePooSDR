using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeReservas.API.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionServicioAdicional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "reserva_id",
                table: "servicio_adicional",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservaId1",
                table: "reservas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_reservas_ReservaId1",
                table: "reservas",
                column: "ReservaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_reservas_reservas_ReservaId1",
                table: "reservas",
                column: "ReservaId1",
                principalTable: "reservas",
                principalColumn: "reserva_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservas_reservas_ReservaId1",
                table: "reservas");

            migrationBuilder.DropIndex(
                name: "IX_reservas_ReservaId1",
                table: "reservas");

            migrationBuilder.DropColumn(
                name: "reserva_id",
                table: "servicio_adicional");

            migrationBuilder.DropColumn(
                name: "ReservaId1",
                table: "reservas");
        }
    }
}
