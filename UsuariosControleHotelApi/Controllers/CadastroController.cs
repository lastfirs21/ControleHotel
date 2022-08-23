using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosControleHotelApi.Data.Dto;

namespace UsuariosControleHotelApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDto createDto)
        {
            //TODO: Chamar Serviço
            return Ok();
        }

    }
}
