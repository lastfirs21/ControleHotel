using ControleHotel.Data.Dtos.Hospedagem;
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
    public class HospedagemController : ControllerBase
    {

        private HospedagemService _hospedagemService;
        public HospedagemController(HospedagemService hospedagemService)
        {
            _hospedagemService = hospedagemService;
        }

        [HttpPost]
        //[Authorize(Roles = "admin")] TODO: AINDA ESTA SEM AUTORIZACAO
        public IActionResult AdicionaHospedagem([FromBody] CreateHospedagemDto hospedagemDto)
        {
            Result resultado = _hospedagemService.AdicionaHospedagem(hospedagemDto);

            if (resultado.IsFailed)
            {
                return NotFound(resultado);
            }
            else
            {
                return Ok("Nova Hospedagem Adicionada");
            }
        }

        [HttpPost("{reservaId}")]
        public IActionResult AddHospedagemPorReserva(int reservaId)
        {
            Result resultado = _hospedagemService.AdicionaHospedagemPorReserva(reservaId);

            if (resultado.IsFailed)
            {
                return NotFound(resultado);
            }
            else
            {
                return Ok("Nova Hospedagem Criada a Partir de Reserva");
            }
        }



        [HttpGet]
        public IActionResult RecuperaHospedagem()
        {
            List<ReadHospedagemDto> readDto = _hospedagemService.RecuperaHospedagens();
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaHospedagemPorId(int id)
        {
            ReadHospedagemDto readDto = _hospedagemService.RecuperaHospedagensPorId(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);

        }
       


        [HttpDelete("{id}")]
        public IActionResult DeletaHospedagem(int id)
        {
            Result resultado = _hospedagemService.DeletaHospedagem(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();

        }

        [HttpPut("{id}")]
        public IActionResult AtualizaHospedagem(int id, [FromBody] UpdateHospedagemDto hospedagemDto)
        {
            Result resultado = _hospedagemService.AtualizaHospedagem(id, hospedagemDto);
            if (resultado.IsFailed) return NotFound(resultado);
            return Ok("Atualização Realizada com Sucesso");
        }
    }

}

