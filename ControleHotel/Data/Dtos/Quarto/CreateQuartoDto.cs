using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleHotel.Data.Dtos.Quarto
{
    public class CreateQuartoDto
    {
        [Required(ErrorMessage = "O campo de Descricao é obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo de Valor é obrigatório")]
        public double Valor { get; set; }
    }
}
