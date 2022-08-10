using ControleHotel.Data.Dtos.Reserva;
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
            ReadReservaDto readDto = _reservaService.AdicionaReserva(ReservaDto);
            return CreatedAtAction(nameof(RecuperaReservaPorId), new { Id = readDto.Id }, readDto);
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
        public IActionResult AtualizaReserva(int id, [FromBody] UpdateReservaDto ReservaDto)
        {
            Result resultado = _reservaService.AtualizaReserva(id, ReservaDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
