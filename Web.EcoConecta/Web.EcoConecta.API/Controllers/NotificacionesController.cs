using Microsoft.AspNetCore.Mvc;
using Web.EcoConecta.CORE.Core.Interfaces;
using Web.EcoConecta.CORE.Core.Entities;

namespace Web.EcoConecta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacionesController : ControllerBase
    {
        private readonly INotificacionesService _service;

        public NotificacionesController(INotificacionesService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Notificaciones dto)
        {
            var id = await _service.CrearNotificacionAsync(dto);
            if (id == 0) return BadRequest();
            return Ok(id);
        }

        [HttpGet("usuario/{idUsuario}")]
        public async Task<IActionResult> GetByUsuario(int idUsuario)
        {
            var res = await _service.GetByUsuarioAsync(idUsuario);
            return Ok(res);
        }
    }
}
