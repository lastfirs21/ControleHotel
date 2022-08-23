using ControleHotel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleHotel.Data.Dtos.Hospedagem
{
    public class CreateHospedagemDto
    {
        [Required(ErrorMessage = "É Necessário Definir o Quarto Para Realizar a Hospedagem")]
        public int QuartoId { get; set; }

        [Required(ErrorMessage = "É Necessário Definir o Hospede Para Realizar a Hospedagem")]
        public int HospedeId { get; set; }

        [Required(ErrorMessage = "A Data de Check-In é Necessária!")]

        public DateTime DataCheckIn { get; set; }

        [Required(ErrorMessage = "A Data de Check-Out é Necessária!")]
        public DateTime DataCheckOut { get; set; }

        public StatusHospedagem StatusHospedagem { get; set; }
    }
}
