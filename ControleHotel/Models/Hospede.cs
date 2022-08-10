using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ControleHotel.Models
{   
    public class Hospede
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Um Hospede Precisa Ter Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Um Hospede Precisa Ter CPF")]
        public string CPF { get; set; }
        [JsonIgnore]
        public virtual List<Reserva> Reservas { get; set; }

    }
}