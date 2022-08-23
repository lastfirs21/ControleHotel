using ControleHotel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleHotel.Data.Dtos.Reserva
{
    public class UpdateReservaDto
    {
        public int QuartoId { get; set; }

        public int HospedeId { get; set; }

        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }

        public int PeriodoDeDias { get; set; }

        public StatusReserva StatusReserva { get; set; }
    }
}
