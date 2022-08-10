using ControleHotel.Data.Dtos.Quarto;
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
    public class QuartoController : ControllerBase
    {
        private QuartoService _quartoService;

        public QuartoController(QuartoService quartoService)
        {
            _quartoService = quartoService;
        }

        [HttpPost]
        //[Authorize(Roles = "admin")] TODO: AINDA ESTA SEM AUTORIZACAO
        public IActionResult AdicionaQuarto([FromBody] CreateQuartoDto QuartoDto)
        {
            ReadQuartoDto readDto = _quartoService.AdicionaQuarto(QuartoDto);
            return CreatedAtAction(nameof(RecuperaQuartoPorId), new { Id = readDto.Id }, readDto);
        }


        [HttpGet]
        public IActionResult RecuperaQuarto()
        {
            List<ReadQuartoDto> readDto = _quartoService.RecuperaQuartos();
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaQuartoPorId(int id)
        {
            ReadQuartoDto readDto = _quartoService.RecuperaQuartosPorId(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);

        }

        [HttpDelete("{id}")]
        public IActionResult DeletaQuarto(int id)
        {
            Result resultado = _quartoService.DeletaQuarto(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();

        }

        [HttpPut("{id}")]
        public IActionResult AtualizaQuarto(int id, [FromBody] UpdateQuartoDto QuartoDto)
        {
            Result resultado = _quartoService.AtualizaQuarto(id, QuartoDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
