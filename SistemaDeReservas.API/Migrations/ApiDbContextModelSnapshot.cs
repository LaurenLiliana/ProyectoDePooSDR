﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaDeReservas.API.Database;

#nullable disable

namespace SistemaDeReservas.API.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.4");

            modelBuilder.Entity("SistemaDeReservas.API.Database.Entities.ClienteEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("apellido");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<string>("DocumentoId")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("documento_id");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("nombre");

                    b.Property<string>("Teléfono")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("telefono");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("clientes");
                });

            modelBuilder.Entity("SistemaDeReservas.API.Database.Entities.HabitacionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int>("Capacidad")
                        .HasColumnType("INTEGER")
                        .HasColumnName("capacity");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<string>("Descripción")
                        .HasColumnType("TEXT")
                        .HasColumnName("description");

                    b.Property<bool>("Disponible")
                        .HasColumnType("INTEGER")
                        .HasColumnName("disponible");

                    b.Property<int>("HotelId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("hotel_id");

                    b.Property<string>("Número")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("numero");

                    b.Property<decimal>("PrecioPorNoche")
                        .HasColumnType("TEXT")
                        .HasColumnName("precio_por_noche");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("tipo");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("habitaciones");
                });

            modelBuilder.Entity("SistemaDeReservas.API.Database.Entities.HotelEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("ciudad");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<string>("Dirección")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT")
                        .HasColumnName("direccion");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT")
                        .HasColumnName("email");

                    b.Property<int>("Estrellas")
                        .HasColumnType("INTEGER")
                        .HasColumnName("estrellas");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("nombre");

                    b.Property<string>("País")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("pais");

                    b.Property<string>("Teléfono")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("telefono");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("hoteles");
                });

            modelBuilder.Entity("SistemaDeReservas.API.Database.Entities.PagoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("estado");

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("TEXT")
                        .HasColumnName("fecha_pago");

                    b.Property<string>("MetodoPago")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("metodo_pago");

                    b.Property<int>("ReservaId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("reserva_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("ReservaId");

                    b.ToTable("pagos");
                });

            modelBuilder.Entity("SistemaDeReservas.API.Database.Entities.ReservaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("cliente_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("estado");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("TEXT")
                        .HasColumnName("FechaFin");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("TEXT")
                        .HasColumnName("FechaInicio");

                    b.Property<int>("HabitaciónId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("habitacion_id");

                    b.Property<decimal>("TotalPago")
                        .HasColumnType("TEXT")
                        .HasColumnName("total_pago");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("HabitaciónId");

                    b.ToTable("reservas");
                });

            modelBuilder.Entity("SistemaDeReservas.API.Database.Entities.ServicioAdicionalEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<string>("Descripción")
                        .HasColumnType("TEXT")
                        .HasColumnName("descripcion");

                    b.Property<bool>("Disponible")
                        .HasColumnType("INTEGER")
                        .HasColumnName("disponible");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("nombre");

                    b.Property<decimal>("Precio")
                        .HasColumnType("TEXT")
                        .HasColumnName("precio");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("servicio_adicional");
                });

            modelBuilder.Entity("SistemaDeReservas.API.Database.Entities.HabitacionEntity", b =>
                {
                    b.HasOne("SistemaDeReservas.API.Database.Entities.HotelEntity", "Hotel")
                        .WithMany("Habitaciones")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("SistemaDeReservas.API.Database.Entities.PagoEntity", b =>
                {
                    b.HasOne("SistemaDeReservas.API.Database.Entities.ReservaEntity", "Reserva")
                        .WithMany("Pagos")
                        .HasForeignKey("ReservaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reserva");
                });

            modelBuilder.Entity("SistemaDeReservas.API.Database.Entities.ReservaEntity", b =>
                {
                    b.HasOne("SistemaDeReservas.API.Database.Entities.ClienteEntity", "Cliente")
                        .WithMany("Reservas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaDeReservas.API.Database.Entities.HabitacionEntity", "Habitación")
                        .WithMany("Reservas")
                        .HasForeignKey("HabitaciónId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Habitación");
                });

            modelBuilder.Entity("SistemaDeReservas.API.Database.Entities.ClienteEntity", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("SistemaDeReservas.API.Database.Entities.HabitacionEntity", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("SistemaDeReservas.API.Database.Entities.HotelEntity", b =>
                {
                    b.Navigation("Habitaciones");
                });

            modelBuilder.Entity("SistemaDeReservas.API.Database.Entities.ReservaEntity", b =>
                {
                    b.Navigation("Pagos");
                });
#pragma warning restore 612, 618
        }
    }
}
