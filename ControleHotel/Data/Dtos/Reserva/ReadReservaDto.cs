using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleHotel.Data.Dtos.Reserva
{
    public class ReadReservaDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "É Necessário Definir o Quarto Para Realizar a Reserva")]
        public int QuartoId { get; set; }

        [Required(ErrorMessage = "É Necessário Definir o Hospede Para Realizar a Reserva")]
        public int HospedeId { get; set; }

        [Required(ErrorMessage = "A Data de Check-In é Necessária!")]

        public DateTime DataCheckIn { get; set; }

        [Required(ErrorMessage = "A Quantidade de Dias da Reserva é Necessária!")]

        public int DiasReserva { get; set; }
    }
}
