using Microsoft.EntityFrameworkCore;
using SistemaDeReservas.API.Database.Entities;

namespace SistemaDeReservas.API.Database
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }
        public DbSet<HotelEntity> Hoteles { get; set; }
        public DbSet<HabitacionEntity> Habitaciones { get; set; }
        public DbSet<ClienteEntity> Clientes { get; set; }
        public DbSet<ReservaEntity> Reservas { get; set; }
        public DbSet<PagoEntity> Pagos { get; set; }
        public DbSet<ServicioAdicionalEntity> ServiciosAdicionales { get; set; }
    }
}