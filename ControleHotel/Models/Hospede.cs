using System;
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

        [Required(ErrorMessage = "Necessário a Data de Nascimento do Hospede?")]
        public DateTime DataNasc { get; set; }

        [JsonIgnore]
        public virtual List<Reserva> Reservas { get; set; }

        [JsonIgnore]
        public virtual List<Hospedagem> Hospedagems { get; set; }

        [Required(ErrorMessage = "Necessário o CEP!")]
        public string CEP { get; set; }
        [Required(ErrorMessage = "Necessário o Estado!")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "Necessário o Cidade!")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Necessário o Rua!")]
        public string Rua { get; set; }
        [Required(ErrorMessage = "Necessário o Numero!")]
        public string Numero { get; set; }
        [Required(ErrorMessage = "Necessário o Bairro!")]
        public string Bairro { get; set; }
        public string Complemento { get; set; }


    }
}