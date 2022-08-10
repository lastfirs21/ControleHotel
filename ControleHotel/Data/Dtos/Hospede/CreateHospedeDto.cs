using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleHotel.Data.Dtos.Hospede
{
    public class CreateHospedeDto
    {
        [Required(ErrorMessage = "Um Hospede Precisa Ter Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Um Hospede Precisa Ter CPF")]
        public string CPF { get; set; }
    }
}
