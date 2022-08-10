using System;
using System.ComponentModel.DataAnnotations;

namespace ControleHotel.Models
{
    public class Reserva
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "A Data de Check-In é Necessária!")]

        public DateTime DataCheckIn { get; set; }



        [Required(ErrorMessage = "A Quantidade de Dias da Reserva é Necessária!")]

        public int DiasReserva { get; set; }
        public virtual Quarto Quarto { get; set; }
        public virtual Hospede Hospede { get; set; }

        [Required(ErrorMessage = "É Necessário Definir o Quarto Para Realizar a Reserva")]

        public int QuartoId { get; set; }



        [Required(ErrorMessage = "É Necessário Definir o Hospede Para Realizar a Reserva")]
        public int HospedeId { get; set; }



     

    }
}