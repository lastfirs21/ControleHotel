using ControleHotel.Data.Dtos.Hospede;
using ControleHotel.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleHotel.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class HospedeController : ControllerBase
    {
        private HospedeService _hospedeService;

        public HospedeController(HospedeService hospedeService)
        {
            _hospedeService = hospedeService;
        }

        [HttpPost]
       //[Authorize(Roles = "admin")] TODO: AINDA ESTA SEM AUTORIZACAO
        public IActionResult AdicionaHospede([FromBody] CreateHospedeDto hospedeDto)
        {
            ReadHospedeDto readDto = _hospedeService.AdicionaHospede(hospedeDto);
            return CreatedAtAction(nameof(RecuperaHospedesPorId), new { Id = readDto.Id }, readDto);
        }


        [HttpGet]
        public IActionResult RecuperaHospede()
        {
            List<ReadHospedeDto> readDto = _hospedeService.RecuperaHospedes();
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaHospedesPorId(int id)
        {
            ReadHospedeDto readDto = _hospedeService.RecuperaHospedesPorId(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);

        }

        [HttpDelete("{id}")]
        public IActionResult DeletaHospede(int id)
        {
            Result resultado = _hospedeService.DeletaHospede(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();

        }

        [HttpPut("{id}")]
        public IActionResult AtualizaHospede(int id, [FromBody] UpdateHospedeDto hospedeDto)
        {
            Result resultado = _hospedeService.AtualizaHospede(id, hospedeDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

    }
}
