﻿using SistemaDeReservas.API.Dtos.Reservas;

namespace SistemaDeReservas.API.Dtos.Cliente
{
    public class ClienteActionResponseDto
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }

        public List<ReservaActionResponseDto> Reservas { get; set; }
    }
}