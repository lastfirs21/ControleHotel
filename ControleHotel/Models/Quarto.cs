using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ControleHotel.Models
{
    public class Quarto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo de Descricao é obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo de Valor é obrigatório")]
        public double Valor { get; set; }
        [JsonIgnore]
        public virtual List<Reserva> Reservas { get; set; }
    }
}

