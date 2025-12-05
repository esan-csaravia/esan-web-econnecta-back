using Microsoft.AspNetCore.Mvc;
using Web.EcoConecta.CORE.Core.DTOs;
using Web.EcoConecta.CORE.Core.Interfaces;

namespace Web.EcoConecta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloqueosUsuariosController : ControllerBase
    {
        private readonly IBloqueosUsuariosService _service;

        public BloqueosUsuariosController(IBloqueosUsuariosService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] BloqueosUsuariosDTO.CreateBloqueoDTO dto)
        {
            var id = await _service.CrearAsync(dto);
            return Ok(new { id });
        }

        [HttpGet("{idUsuario}")]
        public async Task<IActionResult> GetHistorial(int idUsuario)
        {
            var historial = await _service.GetHistorialAsync(idUsuario);
            return Ok(historial);
        }
    }
}
