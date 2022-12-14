using ControleHotel.Data.Dtos.Reserva;
using ControleHotel.Models;
using ControleHotel.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleHotel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservaController : ControllerBase
    {
        private ReservaService _reservaService;

        public ReservaController(ReservaService ReservaService)
        {
            _reservaService = ReservaService;
        }

        [HttpPost]
        //[Authorize(Roles = "admin")] TODO: AINDA ESTA SEM AUTORIZACAO
        public IActionResult AdicionaReserva([FromBody] CreateReservaDto ReservaDto)
        {
            Result resultado = _reservaService.AdicionaReserva(ReservaDto);

            if (resultado.IsFailed)
            {
                return NotFound(resultado);
            }
            else
            {
                return Ok("Nova Reserva Adicionada");
            }
        }


        [HttpGet]
        public IActionResult RecuperaReserva()
        {
            List<ReadReservaDto> readDto = _reservaService.RecuperaReservas();
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaReservaPorId(int id)
        {
            ReadReservaDto readDto = _reservaService.RecuperaReservasPorId(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);

        }

        [HttpDelete("{id}")]
        public IActionResult DeletaReserva(int id)
        {
            Result resultado = _reservaService.DeletaReserva(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();

        }


        [HttpPut("{id}")]
        public IActionResult AtualizaReserva(int id, [FromBody] UpdateReservaDto reservaDto)
        {
            Result resultado = _reservaService.AtualizaReserva(id, reservaDto);
            if (resultado.IsFailed) return NotFound(resultado);
            return Ok("Atualização Realizada com Sucesso");
        }


    }
}
